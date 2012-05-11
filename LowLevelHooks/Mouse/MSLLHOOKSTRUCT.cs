using System;
using System.Runtime.InteropServices;
using System.Drawing;

namespace LowLevelHooks.Mouse
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MSLLHOOKSTRUCT
    {
        public Point Point { get; set; }
        public int MouseData { get; set; }
        public uint Flags { get; set; }
        public uint Time { get; set; }
        public IntPtr DwExtraInfo { get; set; }
    }
}
