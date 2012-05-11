using System;
using System.Runtime.InteropServices;

namespace LowLevelHooks.Keyboard
{
    [StructLayout(LayoutKind.Sequential)]
    public struct KBDLLHOOKSTRUCT
    {
        public int VkCode { get; set; }
        public uint ScanCode { get; set; }
        public uint Flags { get; set; }
        public uint Time { get; set; }
        public IntPtr DwExtraInfo { get; set; }
    }
}
