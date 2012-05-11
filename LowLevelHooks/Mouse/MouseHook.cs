using System;
using System.Runtime.InteropServices;

namespace LowLevelHooks.Mouse
{
    public sealed class MouseHook : IDisposable, IHook
    {
        #region Custom Events
        public event EventHandler<MouseHookEventArgs> Move;

        private void OnMove(MouseHookEventArgs e)
        {
            if (Move != null)
                Move(this, e);
            OnMouseEvent(e);
        }

        public event EventHandler<MouseHookEventArgs> LeftButtonDown;

        private void OnLeftButtonDown(MouseHookEventArgs e)
        {
            if (LeftButtonDown != null)
                LeftButtonDown(this, e);
            OnMouseEvent(e);
        }

        public event EventHandler<MouseHookEventArgs> LeftButtonUp;

        private void OnLeftButtonUp(MouseHookEventArgs e)
        {
            if (LeftButtonUp != null)
                LeftButtonUp(this, e);
            OnMouseEvent(e);
        }

        public event EventHandler<MouseHookEventArgs> RightButtonDown;

        private void OnRightButtonDown(MouseHookEventArgs e)
        {
            if (RightButtonDown != null)
                RightButtonDown(this, e);
            OnMouseEvent(e);
        }

        public event EventHandler<MouseHookEventArgs> RightButtonUp;

        private void OnRightButtonUp(MouseHookEventArgs e)
        {
            if (RightButtonUp != null)
                RightButtonUp(this, e);
            OnMouseEvent(e);
        }
        public event EventHandler<MouseHookEventArgs> MiddleButtonDown;

        private void OnMiddleButtonDown(MouseHookEventArgs e)
        {
            if (MiddleButtonDown != null)
                MiddleButtonDown(this, e);
            OnMouseEvent(e);
        }

        public event EventHandler<MouseHookEventArgs> MiddleButtonUp;

        private void OnMiddleButtonUp(MouseHookEventArgs e)
        {
            if (MiddleButtonUp != null)
                MiddleButtonUp(this, e);
            OnMouseEvent(e);
        }

        public event EventHandler<MouseHookEventArgs> Wheel;

        private void OnWheel(MouseHookEventArgs e)
        {
            if (Wheel != null)
                Wheel(this, e);
            OnMouseEvent(e);
        }
        public event EventHandler<MouseHookEventArgs> MouseEvent;

        private void OnMouseEvent(MouseHookEventArgs e)
        {
            if (MouseEvent != null)
                MouseEvent(this, e);
        }
        #endregion

        /// <summary>
        /// The hook Id we create. This is stored so we can unhook later.
        /// </summary>
        private IntPtr hookId;
        private readonly LowLevelProc callback;
        private bool hooked;

        public MouseHook()
        {
            callback = MouseHookCallback;
        }

        public void Hook()
        {
            hookId = Win32.SetWindowsHook(Win32.Hooks.WH_MOUSE_LL, callback);
            hooked = true;
        }

        public void Unhook()
        {
            if (!hooked) return;
            NativeMethods.UnhookWindowsHookEx(hookId);
            hooked = false;
        }

        /// <summary>
        /// This is the callback method that is called whenever a low level mouse event is triggered.
        /// We use it to call our individual custom events.
        /// </summary>
        private IntPtr MouseHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                var lParamStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                var e = new MouseHookEventArgs(lParamStruct);
                switch ((MouseMessages)wParam)
                {
                    case MouseMessages.WmMouseMove:
                        TriggerMouseEvent(e, MouseEventNames.MouseMove, OnMove);
                        break;
                    case MouseMessages.WmLButtonDown:
                        TriggerMouseEvent(e, MouseEventNames.LeftButtonDown, OnLeftButtonDown);
                        break;
                    case MouseMessages.WmLButtonUp:
                        TriggerMouseEvent(e, MouseEventNames.LeftButtonUp, OnLeftButtonUp);
                        break;
                    case MouseMessages.WmRButtonDown:
                        TriggerMouseEvent(e, MouseEventNames.RightButtonDown, OnRightButtonDown);
                        break;
                    case MouseMessages.WmRButtonUp:
                        TriggerMouseEvent(e, MouseEventNames.RightButtonUp, OnRightButtonUp);
                        break;
                    case MouseMessages.WmMButtonDown:
                        TriggerMouseEvent(e, MouseEventNames.MiddleButtonDown, OnMiddleButtonDown);
                        break;
                    case MouseMessages.WmMButtonUp:
                        TriggerMouseEvent(e, MouseEventNames.MouseMove, OnMove);
                        e.MouseEventName = MouseEventNames.MiddleButtonUp;
                        OnMiddleButtonUp(e);
                        break;
                    case MouseMessages.WmMouseWheel:
                        TriggerMouseEvent(e, MouseEventNames.MouseMove, OnMove);
                        e.MouseEventName = MouseEventNames.MouseWheel;
                        OnWheel(e);
                        break;
                }
            }
            return NativeMethods.CallNextHookEx(hookId, nCode, wParam, lParam);
        }

        private static void TriggerMouseEvent(MouseHookEventArgs e, MouseEventNames name, Action<MouseHookEventArgs> method)
        {
            e.MouseEventName = name;
            method(e);
        }

        #region IDisposable Members / Finalizer
        /// <summary>
        /// Call this method to unhook the Mouse Hook, and to release resources allocated to it.
        /// </summary>
        public void Dispose()
        {
            Unhook();
            GC.SuppressFinalize(this);
        }

        ~MouseHook()
        {
            Unhook();
        }

        #endregion
    }
}
