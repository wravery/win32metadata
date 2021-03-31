﻿using System;
using System.Runtime.InteropServices;
using Windows.Win32.Interop;

namespace Windows.Win32.WindowsProgramming
{
    public static unsafe partial class Apis
    {
        [NativeTypeName("HKEY")]
        public const int HKEY_CLASSES_ROOT = unchecked((int)0x80000000);

        [NativeTypeName("HKEY")]
        public const int HKEY_CURRENT_USER = unchecked((int)0x80000001);

        [NativeTypeName("HKEY")]
        public const int HKEY_LOCAL_MACHINE = unchecked((int)0x80000002);

        [NativeTypeName("HKEY")]
        public const int HKEY_USERS = unchecked((int)0x80000003);

        [NativeTypeName("HKEY")]
        public const int HKEY_PERFORMANCE_DATA = unchecked((int)0x80000004);

        [NativeTypeName("HKEY")]
        public const int HKEY_PERFORMANCE_TEXT = unchecked((int)0x80000050);

        [NativeTypeName("HKEY")]
        public const int HKEY_PERFORMANCE_NLSTEXT = unchecked((int)0x80000060);

        [NativeTypeName("HKEY")]
        public const int HKEY_CURRENT_CONFIG = unchecked((int)0x80000005);

        [NativeTypeName("HKEY")]
        public const int HKEY_DYN_DATA = unchecked((int)0x80000006);

        [NativeTypeName("HKEY")]
        public const int HKEY_CURRENT_USER_LOCAL_SETTINGS = unchecked((int)0x80000007);
    }

    [Flags]
    public enum PROCESS_CREATION_FLAGS : uint
    {
        DEBUG_PROCESS = 0x00000001,
        DEBUG_ONLY_THIS_PROCESS = 0x00000002,
        CREATE_SUSPENDED = 0x00000004,
        DETACHED_PROCESS = 0x00000008,
        CREATE_NEW_CONSOLE = 0x00000010,
        NORMAL_PRIORITY_CLASS = 0x00000020,
        IDLE_PRIORITY_CLASS = 0x00000040,
        HIGH_PRIORITY_CLASS = 0x00000080,
        REALTIME_PRIORITY_CLASS = 0x00000100,
        CREATE_NEW_PROCESS_GROUP = 0x00000200,
        CREATE_UNICODE_ENVIRONMENT = 0x00000400,
        CREATE_SEPARATE_WOW_VDM = 0x00000800,
        CREATE_SHARED_WOW_VDM = 0x00001000,
        CREATE_FORCEDOS = 0x00002000,
        BELOW_NORMAL_PRIORITY_CLASS = 0x00004000,
        ABOVE_NORMAL_PRIORITY_CLASS = 0x00008000,
        INHERIT_PARENT_AFFINITY = 0x00010000,
        INHERIT_CALLER_PRIORITY = 0x00020000,
        CREATE_PROTECTED_PROCESS = 0x00040000,
        EXTENDED_STARTUPINFO_PRESENT = 0x00080000,
        PROCESS_MODE_BACKGROUND_BEGIN = 0x00100000,
        PROCESS_MODE_BACKGROUND_END = 0x00200000,
        CREATE_SECURE_PROCESS = 0x00400000,
        CREATE_BREAKAWAY_FROM_JOB = 0x01000000,
        CREATE_PRESERVE_CODE_AUTHZ_LEVEL = 0x02000000,
        CREATE_DEFAULT_ERROR_MODE = 0x04000000,
        CREATE_NO_WINDOW = 0x08000000,
        PROFILE_USER = 0x10000000,
        PROFILE_KERNEL = 0x20000000,
        PROFILE_SERVER = 0x40000000,
        CREATE_IGNORE_SYSTEM_DEFAULT = 0x80000000
    }

    public enum HANDLE_FLAG_OPTIONS
    {
        HANDLE_FLAG_INHERIT = 0x00000001,
        HANDLE_FLAG_PROTECT_FROM_CLOSE = 0x00000002
    }

    public enum DUPLICATE_HANDLE_OPTIONS
    {
        DUPLICATE_CLOSE_SOURCE = 0x00000001,
        DUPLICATE_SAME_ACCESS = 0x00000002
    }

    public enum STD_HANDLE_TYPE : uint
    {
        STD_INPUT_HANDLE = unchecked((uint)-10),
        STD_OUTPUT_HANDLE = unchecked((uint)-11),
        STD_ERROR_HANDLE = unchecked((uint)-12),
    }

    [Flags]
    public enum VER_FLAGS : uint
    {
        VER_MINORVERSION = 0x0000001,
        VER_MAJORVERSION = 0x0000002,
        VER_BUILDNUMBER = 0x0000004,
        VER_PLATFORMID = 0x0000008,
        VER_SERVICEPACKMINOR = 0x0000010,
        VER_SERVICEPACKMAJOR = 0x0000020,
        VER_SUITENAME = 0x0000040,
        VER_PRODUCT_TYPE = 0x0000080
    }

    public enum REG_VALUE_TYPE : uint
    {
        REG_NONE = 0,
        REG_SZ = 1,
        REG_EXPAND_SZ = 2,
        REG_BINARY = 3,
        REG_DWORD = 4,
        REG_DWORD_LITTLE_ENDIAN = 4,
        REG_DWORD_BIG_ENDIAN = 5,
        REG_LINK = 6,
        REG_MULTI_SZ = 7,
        REG_RESOURCE_LIST = 8,
        REG_FULL_RESOURCE_DESCRIPTOR =  9,
        REG_RESOURCE_REQUIREMENTS_LIST = 10,
        REG_QWORD = 11,
        REG_QWORD_LITTLE_ENDIAN = 11
    }

    [Flags]
    public enum REG_SAM_FLAGS : uint
    {
        KEY_QUERY_VALUE = 0x0001,
        KEY_SET_VALUE = 0x0002,
        KEY_CREATE_SUB_KEY = 0x0004,
        KEY_ENUMERATE_SUB_KEYS = 0x0008,
        KEY_NOTIFY = 0x0010,
        KEY_CREATE_LINK = 0x0020,
        KEY_WOW64_32KEY = 0x0200,
        KEY_WOW64_64KEY = 0x0100,
        KEY_WOW64_RES = 0x0300,

        KEY_READ = 0x20019,
        KEY_WRITE = 0x20006,
        KEY_EXECUTE = 0x20019,
        KEY_ALL_ACCESS = 0xF003F
    }

    [Flags]
    public enum REG_OPEN_CREATE_OPTIONS : uint
    {
        REG_OPTION_RESERVED = 0x00000000,
        REG_OPTION_NON_VOLATILE = 0x00000000,
        REG_OPTION_VOLATILE  = 0x00000001,
        REG_OPTION_CREATE_LINK = 0x00000002,
        REG_OPTION_BACKUP_RESTORE = 0x00000004,
        REG_OPTION_OPEN_LINK = 0x00000008,
        REG_OPTION_DONT_VIRTUALIZE = 0x00000010
    }

    public enum REG_CREATE_KEY_DISPOSITION : uint
    {
        REG_CREATED_NEW_KEY = 0x00000001,
        REG_OPENED_EXISTING_KEY = 0x00000002
    }
}
