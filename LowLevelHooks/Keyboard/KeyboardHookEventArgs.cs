using System;
using System.Windows.Forms;

namespace LowLevelHooks.Keyboard {
    public class KeyboardHookEventArgs : HookEventArgs {
        public KeyboardHookEventArgs(KBDLLHOOKSTRUCT lparam) {
            EventType = HookEventType.Keyboard;
            LParam = lparam;
        }

        private KBDLLHOOKSTRUCT _LParam;
        public KBDLLHOOKSTRUCT LParam {
            get { return _LParam; }
            private set {
                _LParam = value;
                uint nonVirtual = Win32.MapVirtualKey((uint)VirtualKeyCode, (uint)2);
                _Char = Convert.ToChar(nonVirtual);
            }
        }

        public int VirtualKeyCode { get { return LParam.VkCode; } }

        public Keys Key { get { return (Keys)VirtualKeyCode; } }

        private char _Char;
        public char Char {
            get {
                return _Char;
            }
            private set {
                _Char = value;
            }
        }

        public string KeyString {
            get {
                if (Char == '\0') {
                    if (Key == Keys.Return)
                        return "[Enter]";
                    return string.Format("[{0}]", Key.ToString());
                }
                else {
                    if (Char == '\r') {
                        Char = '\0';
                        return "[Enter]";
                    }
                    if (Char == '\b') {
                        Char = '\0';
                        return "[Backspace]";
                    }
                    return this.Char.ToString();
                }
            }
        }

        public KeyboardEventNames KeyboardEventName { get; internal set; }
    }
}
