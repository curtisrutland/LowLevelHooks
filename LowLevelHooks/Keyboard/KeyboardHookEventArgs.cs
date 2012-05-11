using System;
using System.Globalization;
using System.Windows.Forms;

namespace LowLevelHooks.Keyboard
{
    public class KeyboardHookEventArgs : HookEventArgs
    {
        public KeyboardHookEventArgs(KBDLLHOOKSTRUCT lparam)
        {
            EventType = HookEventType.Keyboard;
            LParam = lparam;
        }

        private KBDLLHOOKSTRUCT lParam;

        private KBDLLHOOKSTRUCT LParam
        {
            get { return lParam; }
            set
            {
                lParam = value;
                var nonVirtual = NativeMethods.MapVirtualKey((uint)VirtualKeyCode, 2);
                Char = Convert.ToChar(nonVirtual);
            }
        }

        public int VirtualKeyCode { get { return LParam.VkCode; } }

        public Keys Key { get { return (Keys)VirtualKeyCode; } }

        public char Char { get; private set; }

        public string KeyString
        {
            get
            {
                if (Char == '\0')
                {
                    return Key == Keys.Return ? "[Enter]" : string.Format("[{0}]", Key);
                }
                if (Char == '\r')
                {
                    Char = '\0';
                    return "[Enter]";
                }
                if (Char == '\b')
                {
                    Char = '\0';
                    return "[Backspace]";
                }
                return Char.ToString(CultureInfo.InvariantCulture);
            }
        }

        public KeyboardEventNames KeyboardEventName { get; internal set; }
    }
}
