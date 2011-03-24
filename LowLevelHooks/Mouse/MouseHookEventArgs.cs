using System;
using System.Drawing;

namespace LowLevelHooks.Mouse {
    public class MouseHookEventArgs : HookEventArgs {
        public MouseHookEventArgs(MSLLHOOKSTRUCT lparam) {
            EventType = HookEventType.Mouse;
            LParam = lparam;
        }

        public MSLLHOOKSTRUCT LParam { get; private set; }

        public Point Position {
            get {
                return LParam.Point;
            }
        }

        public MouseScrollDirection ScrollDirection {
            get {
                if (MouseEventName != MouseEventNames.MouseWheel)
                    return MouseScrollDirection.None;
                if ((LParam.MouseData >> 16) > 0)
                    return MouseScrollDirection.Up;
                else
                    return MouseScrollDirection.Down;
            }
        }

        public MouseEventNames MouseEventName { get; internal set; }
    }
}
