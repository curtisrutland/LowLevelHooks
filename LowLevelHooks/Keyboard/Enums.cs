
namespace LowLevelHooks.Keyboard {
    public enum KeyboardMessages {
        WM_KEYDOWN = 0x0100,
        WM_KEYUP = 0x0101,
        WM_SYSKEYDOWN = 0x0104,
        WM_SYSKEYUP = 0x0105
    }

    public enum KeyboardEventNames {
        KeyDown,
        KeyUp,
        SystemKeyDown,
        SystemKeyUp
    }
}
