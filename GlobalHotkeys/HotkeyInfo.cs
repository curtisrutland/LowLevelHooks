using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GlobalHotkeys
{
    public class HotkeyInfo
    {
        public Keys Key { get; private set; }
        public Modifiers Modifiers { get; private set; }

        private HotkeyInfo(IntPtr lParam)
        {
            var lpInt = (int)lParam;
            Key = (Keys)((lpInt >> 16) & 0xFFFF);
            Modifiers = (Modifiers)(lpInt & 0xFFFF);
        }

        public static HotkeyInfo GetFromMessage(Message m)
        {
            return !IsHotkeyMessage(m) ? null : new HotkeyInfo(m.LParam);
        }

        public static bool IsHotkeyMessage(Message m)
        {
            return m.Msg == Win32.WM_HOTKEY_MSG_ID;
        }
    }
}
