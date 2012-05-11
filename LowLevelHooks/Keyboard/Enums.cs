
namespace LowLevelHooks.Keyboard
{
    public enum KeyboardMessages
    {
        WmKeydown = 0x0100,
        WmKeyup = 0x0101,
        WmSyskeydown = 0x0104,
        WmSyskeyup = 0x0105
    }

    public enum KeyboardEventNames
    {
        KeyDown,
        KeyUp,
        SystemKeyDown,
        SystemKeyUp
    }
}
