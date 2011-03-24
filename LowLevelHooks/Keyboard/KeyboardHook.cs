using System;
using System.Runtime.InteropServices;

namespace LowLevelHooks.Keyboard {
    public class KeyboardHook : IDisposable, IHook {
        #region Custom Events

        public event EventHandler<KeyboardHookEventArgs> KeyDown;
        protected virtual void OnKeyDown(KeyboardHookEventArgs e) {
            if (KeyDown != null)
                KeyDown(this, e);
            OnKeyEvent(e);
        }

        public event EventHandler<KeyboardHookEventArgs> KeyUp;
        protected virtual void OnKeyUp(KeyboardHookEventArgs e) {
            if (KeyUp != null)
                KeyUp(this, e);
            OnKeyEvent(e);
        }

        public event EventHandler<KeyboardHookEventArgs> KeyEvent;
        protected virtual void OnKeyEvent(KeyboardHookEventArgs e) {
            if (KeyEvent != null)
                KeyEvent(this, e);
        }

        #endregion

        const int WH_KEYBOARD_LL = 13;

        private IntPtr hookId;

        private LowLevelProc callback;

        public KeyboardHook() {
            callback = KeyboardHookCallback;
        }

        ~KeyboardHook() {
            this.Unhook();
        }

        public void Hook() {
            hookId = Win32.SetWindowsHook(WH_KEYBOARD_LL, callback);
        }

        public void Unhook() {
            Win32.UnhookWindowsHookEx(hookId);
        }

        private IntPtr KeyboardHookCallback(int nCode, IntPtr wParam, IntPtr lParam) {
            if (nCode >= 0) {
                KBDLLHOOKSTRUCT lParamStruct = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(KBDLLHOOKSTRUCT));
                KeyboardHookEventArgs e = new KeyboardHookEventArgs(lParamStruct);
                switch ((KeyboardMessages)wParam) {
                    case KeyboardMessages.WM_KEYDOWN:
                        e.KeyboardEventName = KeyboardEventNames.KeyDown;
                        OnKeyDown(e);
                        break;
                    case KeyboardMessages.WM_KEYUP:
                        e.KeyboardEventName = KeyboardEventNames.KeyUp;
                        OnKeyUp(e);
                        break;
                    case KeyboardMessages.WM_SYSKEYDOWN:
                        e.KeyboardEventName = KeyboardEventNames.SystemKeyDown;
                        OnKeyDown(e);
                        break;
                    case KeyboardMessages.WM_SYSKEYUP:
                        e.KeyboardEventName = KeyboardEventNames.SystemKeyUp;
                        OnKeyUp(e);
                        break;
                }
            }
            return Win32.CallNextHookEx(hookId, nCode, wParam, lParam);
        }

        #region IDisposable Members
        /// <summary>
        /// Call this method to unhook the Mouse Hook, and to release resources allocated to it.
        /// </summary>
        public void Dispose() {
            this.Unhook();
        }

        #endregion
    }
}
