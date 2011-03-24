using System;
using System.Runtime.InteropServices;

namespace LowLevelHooks.Mouse {
    public class MouseHook : IDisposable, IHook {
        #region Custom Events
        public event EventHandler<MouseHookEventArgs> Move;
        protected virtual void OnMove(MouseHookEventArgs e) {
            if (Move != null)
                Move(this, e);
            OnMouseEvent(e);
        }

        public event EventHandler<MouseHookEventArgs> LeftButtonDown;
        protected virtual void OnLeftButtonDown(MouseHookEventArgs e) {
            if (LeftButtonDown != null)
                LeftButtonDown(this, e);
            OnMouseEvent(e);
        }

        public event EventHandler<MouseHookEventArgs> LeftButtonUp;
        protected virtual void OnLeftButtonUp(MouseHookEventArgs e) {
            if (LeftButtonUp != null)
                LeftButtonUp(this, e);
            OnMouseEvent(e);
        }

        public event EventHandler<MouseHookEventArgs> RightButtonDown;
        protected virtual void OnRightButtonDown(MouseHookEventArgs e) {
            if (RightButtonDown != null)
                RightButtonDown(this, e);
            OnMouseEvent(e);
        }

        public event EventHandler<MouseHookEventArgs> RightButtonUp;
        protected virtual void OnRightButtonUp(MouseHookEventArgs e) {
            if (RightButtonUp != null)
                RightButtonUp(this, e);
            OnMouseEvent(e);
        }
        public event EventHandler<MouseHookEventArgs> MiddleButtonDown;
        protected virtual void OnMiddleButtonDown(MouseHookEventArgs e) {
            if (MiddleButtonDown != null)
                MiddleButtonDown(this, e);
            OnMouseEvent(e);
        }

        public event EventHandler<MouseHookEventArgs> MiddleButtonUp;
        protected virtual void OnMiddleButtonUp(MouseHookEventArgs e) {
            if (MiddleButtonUp != null)
                MiddleButtonUp(this, e);
            OnMouseEvent(e);
        }

        public event EventHandler<MouseHookEventArgs> Wheel;
        protected virtual void OnWheel(MouseHookEventArgs e) {
            if (Wheel != null)
                Wheel(this, e);
            OnMouseEvent(e);
        }
        public event EventHandler<MouseHookEventArgs> MouseEvent;
        protected virtual void OnMouseEvent(MouseHookEventArgs e) {
            if (MouseEvent != null)
                MouseEvent(this, e);
        }
        #endregion

        /// <summary>
        /// The nCode number identifying a low level mouse event
        /// </summary>
        const int WH_MOUSE_LL = 14;

        /// <summary>
        /// The hook Id we create. This is stored so we can unhook later.
        /// </summary>
        private IntPtr hookId;

        private LowLevelProc callback;

        public MouseHook() {
            callback = MouseHookCallback;
        }

        ~MouseHook() {
            this.Unhook();
        }

        public void Hook() {
            hookId = Win32.SetWindowsHook(WH_MOUSE_LL, callback);
        }

        public void Unhook() {
            Win32.UnhookWindowsHookEx(hookId);
        }

        /// <summary>
        /// This is the callback method that is called whenever a low level mouse event is triggered.
        /// We use it to call our individual custom events.
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        private IntPtr MouseHookCallback(int nCode, IntPtr wParam, IntPtr lParam) {
            if (nCode >= 0) {
                MSLLHOOKSTRUCT lParamStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                MouseHookEventArgs e = new MouseHookEventArgs(lParamStruct);
                switch ((MouseMessages)wParam) {
                    case MouseMessages.WM_MOUSEMOVE:
                        e.MouseEventName = MouseEventNames.MouseMove;
                        OnMove(e);
                        break;
                    case MouseMessages.WM_LBUTTONDOWN:
                        e.MouseEventName = MouseEventNames.LeftButtonDown;
                        OnLeftButtonDown(e);
                        break;
                    case MouseMessages.WM_LBUTTONUP:
                        e.MouseEventName = MouseEventNames.LeftButtonUp;
                        OnLeftButtonUp(e);
                        break;
                    case MouseMessages.WM_RBUTTONDOWN:
                        e.MouseEventName = MouseEventNames.RightButtonDown;
                        OnRightButtonDown(e);
                        break;
                    case MouseMessages.WM_RBUTTONUP:
                        e.MouseEventName = MouseEventNames.RightButtonUp;
                        OnRightButtonUp(e);
                        break;
                    case MouseMessages.WM_MBUTTONDOWN:
                        e.MouseEventName = MouseEventNames.MiddleButtonDown;
                        OnMiddleButtonDown(e);
                        break;
                    case MouseMessages.WM_MBUTTONUP:
                        e.MouseEventName = MouseEventNames.MiddleButtonUp;
                        OnMiddleButtonUp(e);
                        break;
                    case MouseMessages.WM_MOUSEWHEEL:
                        e.MouseEventName = MouseEventNames.MouseWheel;
                        OnWheel(e);
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
