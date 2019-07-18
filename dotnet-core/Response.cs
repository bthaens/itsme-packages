using System.Runtime.InteropServices;
using System;

namespace Itsme
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct Response
    {
        public IntPtr r0;
        public IntPtr r1;
    };
}
