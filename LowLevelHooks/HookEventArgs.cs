using System;

namespace LowLevelHooks {
    public abstract class HookEventArgs : EventArgs {
        public HookEventType EventType {get; internal set;}
    }

    public enum HookEventType {Keyboard, Mouse}
}
