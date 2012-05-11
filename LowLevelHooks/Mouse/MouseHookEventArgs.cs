using System.Drawing;

namespace LowLevelHooks.Mouse
{
    public class MouseHookEventArgs : HookEventArgs
    {
        public MouseHookEventArgs(MSLLHOOKSTRUCT lparam)
        {
            EventType = HookEventType.Mouse;
            LParam = lparam;
        }

        private MSLLHOOKSTRUCT LParam { get; set; }

        public Point Position
        {
            get
            {
                return LParam.Point;
            }
        }

        public MouseScrollDirection ScrollDirection
        {
            get
            {
                if (MouseEventName != MouseEventNames.MouseWheel)
                    return MouseScrollDirection.None;
                return (LParam.MouseData >> 16) > 0 ? MouseScrollDirection.Up : MouseScrollDirection.Down;
            }
        }

        public MouseEventNames MouseEventName { get; internal set; }
    }
}
