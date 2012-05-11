using System;

namespace LowLevelHooks
{
    /// <summary>
    /// This delegate matches the type of parameter "lpfn" for the NativeMethods method "SetWindowsHookEx".
    /// For more information: http://msdn.microsoft.com/en-us/library/ms644986(VS.85).aspx
    /// </summary>
    /// <param name="nCode"></param>
    /// <param name="wParam"></param>
    /// <param name="lParam"></param>
    /// <returns></returns>
    public delegate IntPtr LowLevelProc(int nCode, IntPtr wParam, IntPtr lParam);
}
