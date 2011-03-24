
namespace LowLevelHooks.Mouse {
    public enum MouseMessages {
        WM_MOUSEMOVE = 0x200,
        WM_LBUTTONDOWN = 0x201,
        WM_LBUTTONUP = 0x202,
        WM_RBUTTONDOWN = 0x204,
        WM_RBUTTONUP = 0x205,
        WM_MBUTTONDOWN = 0x207,
        WM_MBUTTONUP = 0x208,
        WM_MOUSEWHEEL = 0x20A,
    }

    public enum MouseEventNames {
        MouseMove,
        LeftButtonDown,
        LeftButtonUp,
        RightButtonDown,
        RightButtonUp,
        MiddleButtonDown,
        MiddleButtonUp,
        MouseWheel
    }

    public enum MouseScrollDirection {
        None = -1,
        Up = 0,
        Down = 1
    }
}
