using System;
using System.Runtime.InteropServices;

using Microsoft.Win32.SafeHandles;

namespace EtwTools
{
    internal static unsafe class Native
    {
        [Flags]
        public enum AccessRights : uint
        {
            Primary = 0x1,
            Duplicate = 0x2,
            Impersonate = 0x4,
            Query = 0x8,
            QuerySource = 0x10,
            AdjustPrivileges = 0x20,
            AdjustGroups = 0x40,
            AdjustSessionId = 0x100,
            StandardRightsRead = 0x20000,
            StandardRightsRequired = 0xF0000,
            Read = StandardRightsRead | Query,
        }

        public enum TokenInformationClass
        {
            User = 1,
            Groups = 2,
            Privileges = 3,
            Owner = 4,
            PrimaryGroup = 5,
            DefaultDacl = 6,
            Source = 7,
            Type = 8,
            ImpersonationLevel = 9,
            Statistics = 10,
            RestrictedSids = 11,
            SessionId = 12,
            GroupsAndPrivileges = 13,
            SessionReference = 14,
            SandBoxInert = 15,
            AuditPolicy = 16,
            Origin = 17,
            ElevationType = 18,
            LinkedToken = 19,
            Elevation = 20,
            HasRestrictions = 21,
            AccessInformation = 22,
            VirtualizationAllowed = 23,
            VirtualizationEnabled = 24,
            IntegrityLevel = 25,
            UIAccess = 26,
            MandatoryPolicy = 27,
            LogonSid = 28,
            Max = 29
        }

        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool OpenProcessToken(SafeProcessHandle processHandle, AccessRights desiredAccess, out SafeAccessTokenHandle handle);

        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetTokenInformation(SafeAccessTokenHandle handle, TokenInformationClass informationClass, void* information, int informationLength, out int returnLength);
    }
}
