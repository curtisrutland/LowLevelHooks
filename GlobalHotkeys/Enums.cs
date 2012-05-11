using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalHotkeys
{
    [Flags]
    public enum Modifiers
    {
        NoMod = 0x0000,
        Alt = 0x0001,
        Ctrl = 0x0002,
        Shift = 0x0004,
        Win = 0x0008
    }
}
