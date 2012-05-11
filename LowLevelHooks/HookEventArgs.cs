using System;

namespace LowLevelHooks
{
    public abstract class HookEventArgs : EventArgs
    {
        protected HookEventType EventType { get; set; }
    }

    public enum HookEventType { Keyboard, Mouse }
}
