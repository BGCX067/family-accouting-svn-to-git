using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace Wang.Velika.Utility.WindowsNativeMethods
{
    public sealed class SafeCloseHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        private SafeCloseHandle()
            : base(true)
        {
        }

        internal SafeCloseHandle(IntPtr handle, bool ownsHandle)
            : base(ownsHandle)
        {
            base.SetHandle(handle);
        }

        [SuppressUnmanagedCodeSecurity]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [DllImport(Constants.KERNEL32, SetLastError = true, ExactSpelling = true)]
        private static extern bool CloseHandle(IntPtr handle);

        protected override bool ReleaseHandle()
        {
            return CloseHandle(base.handle);
        }
    }

 

}
