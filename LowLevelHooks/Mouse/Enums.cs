
namespace LowLevelHooks.Mouse
{
    public enum MouseMessages
    {
        WmMouseMove = 0x200,
        WmLButtonDown = 0x201,
        WmLButtonUp = 0x202,
        WmRButtonDown = 0x204,
        WmRButtonUp = 0x205,
        WmMButtonDown = 0x207,
        WmMButtonUp = 0x208,
        WmMouseWheel = 0x20A,
    }

    public enum MouseEventNames
    {
        MouseMove,
        LeftButtonDown,
        LeftButtonUp,
        RightButtonDown,
        RightButtonUp,
        MiddleButtonDown,
        MiddleButtonUp,
        MouseWheel
    }

    public enum MouseScrollDirection
    {
        None = -1,
        Up = 0,
        Down = 1
    }
}
