
param
(
    [string]
    $artifactsDir = [System.IO.Path]::GetFullPath("$PSScriptRoot\..\artifacts"),

    [string]
    $version,

    [string]
    $partitionName,

    [string]
    $indent = ""
)

. "$PSScriptRoot\CommonUtils.ps1"

if (!$version)
{
    $version = $defaultWinSDKNugetVersion
}

$nugetDestPackagesDir = Join-Path -Path $artifactsDir "InstalledPackages"

$libMappingOutputFileName = Get-LibMappingsFile $artifactsDir $version

$stopwatch =  [system.diagnostics.stopwatch]::StartNew()

$baseGenerateDir = "$rootDir\generation\scraper"
$partitionGenerateDir = "$baseGenerateDir\partitions\$partitionName"
if (!(Test-Path $partitionGenerateDir))
{
    Write-Error "Partition dir $partitionGenerateDir not found."
    exit -1
}

$generationOutArtifactsDir = "$baseGenerateDir\obj"
Create-Directory $generationOutArtifactsDir

$generatorOutput = Join-Path -Path $generationOutArtifactsDir -ChildPath "$partitionName.generation.output.txt"

$withSetLastErrorRsp = "$baseGenerateDir\WithSetLastError.rsp"
$supportedOSRsp = "$baseGenerateDir\supportedOS.rsp"

$baseSettingsRsp = "$baseGenerateDir\baseSettings.rsp"
$partitionSettingsRsp = "$partitionGenerateDir\settings.rsp"
if (!(Test-Path $partitionSettingsRsp))
{
    Write-Error "Partition settings $partitionSettingsRsp not found."
    exit -1
}

$baseRemapRsp = "$baseGenerateDir\baseRemap.rsp"
$autoTypesRemapRsp = "$baseGenerateDir\autoTypes.generated.rsp"
$functionPointerFixupsRsp = "$baseGenerateDir\functionPointerFixups.generated.rsp"

$fixedSettingsRsp = "$generationOutArtifactsDir\$partitionName.fixedSettings.rsp"

Copy-Item $partitionSettingsRsp -Destination $fixedSettingsRsp

$includeRoot = (Get-ChildItem -Path "$nugetDestPackagesDir\Microsoft.Windows.SDK.CPP.$version\c\Include").FullName.Replace('\', '/')
$webview2Root = (Get-ChildItem -Path "$nugetDestPackagesDir\Microsoft.Web.WebView2.1.0.*\build\native").FullName.Replace('\', '/')
$generatedSourceDir = "$rootDir\generation\emitter\generated"
[hashtable]$textToReplaceTable = @{ "<IncludeRoot>" = $includeRoot; "<WebView2Root>" = $webview2Root; "<RepoRoot>" = $rootDir; "<PartitionName>" = $partitionName; "<PartitionDir>" = $partitionGenerateDir; "<GeneratedSourceDir>" = $generatedSourceDir}
Replace-Text $fixedSettingsRsp $textToReplaceTable

Write-Output "$($indent)$partitionName..."
Write-Output "$($indent)$toolsDir\ClangSharpPInvokeGenerator.exe @$baseSettingsRsp @$withSetLastErrorRsp @$supportedOSRsp @$fixedSettingsRsp @$baseRemapRsp @$autoTypesRemapRsp @$functionPointerFixupsRsp @$libMappingOutputFileName > $generatorOutput"

& $toolsDir\ClangSharpPInvokeGenerator.exe "@$baseSettingsRsp" "@$withSetLastErrorRsp" "@$supportedOSRsp" "@$fixedSettingsRsp" "@$baseRemapRsp" "@$autoTypesRemapRsp" "@$functionPointerFixupsRsp" "@$libMappingOutputFileName" > $generatorOutput
if ($LASTEXITCODE -lt 0)
{
    Write-Error "$($indent)ClangSharpPInvokeGenerator.exe failed, full output at $generatorOutput`:"
    $errText = (Get-ChildItem $generatorOutput | select-string "Error: ") -join "`r`n"
    Write-Error $errText

    exit $LastExitCode
}

$possibleRemapsOutput = Join-Path -Path $generationOutArtifactsDir -ChildPath "$partitionName.possibleremaps.output.txt"
& $PSScriptRoot\DisplayPossibleMappings.ps1 -generatorResults $generatorOutput -remapsFile $possibleRemapsOutput

$from = Get-Content -Path $possibleRemapsOutput
if (![string]::IsNullOrEmpty($from))
{
    Add-Content -Path $baseRemapRsp -Value $from
    Write-Output "$($indent)Added remaps to $baseRemapRsp"
}

$stopwatch.Stop()
$totalTime = $stopwatch.Elapsed.ToString("c")
Write-Output "$($indent)Took $totalTime"
