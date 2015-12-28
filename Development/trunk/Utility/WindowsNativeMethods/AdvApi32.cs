using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Wang.Velika.Utility.WindowsNativeMethods
{
    public static class AdvApi32
    {
        public enum LogonProvider
        {
            Default = 0,
            WinNT35 = 1,
            WinNT40 = 2,
            WinNT50 = 3
        }

        public enum LogonType
        {
            Interactive = 2,
            Network = 3,
            Batch =4,
            Service =5,
            Unlock = 7,
            ClearText = 8,
            Credentials = 9
        }


        [DllImport(Constants.ADVAPI32, CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern bool LogonUser([In] string lpszUserName, [In] string lpszDomain, [In] string lpszPassword, [In] LogonType dwLogonType, [In] LogonProvider dwLogonProvider, out SafeCloseHandle phToken);

    }
}
