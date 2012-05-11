using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace LowLevelHooks
{
    internal static class NativeMethods
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr SetWindowsHookEx(int idHook, LowLevelProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        internal static extern uint MapVirtualKey(uint uCode, uint uMapType);
    }

    internal static class Win32
    {
        public static IntPtr SetWindowsHook(int hookType, LowLevelProc callback)
        {
            IntPtr hookId;
            using (var currentProcess = Process.GetCurrentProcess())
            using (var currentModule = currentProcess.MainModule)
            {
                var handle = NativeMethods.GetModuleHandle(currentModule.ModuleName);
                hookId = NativeMethods.SetWindowsHookEx(hookType, callback, handle, 0);
            }
            return hookId;
        }

        /// <summary>
        /// nCode numbers identifying low level Keyboard/Mouse events
        /// </summary>
        public static class Hooks
        {
            public const int WH_KEYBOARD_LL = 13;
            public const int WH_MOUSE_LL = 14;
        }
    }
}
