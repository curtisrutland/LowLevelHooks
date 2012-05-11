using System;
using System.Windows.Forms;

namespace GlobalHotkeys
{
    public class GlobalHotkey : IDisposable
    {
        public Modifiers Modifier { get; private set; }
        public int Key { get; private set; }
        public int Id { get; private set; }

        private readonly IntPtr hWnd;
        private bool registered;

        /// <summary>
        /// Creates a GlobalHotkey object.
        /// </summary>
        /// <param name="modifier">Hotkey modifier keys</param>
        /// <param name="key">Hotkey</param>
        /// <param name="window">The Window that the hotkey should be registered to</param>
        /// <param name="registerImmediately"> </param>
        public GlobalHotkey(Modifiers modifier, Keys key, IWin32Window window, bool registerImmediately = false)
        {
            if (window == null) throw new ArgumentNullException("window", "You must provide a form or window to register the hotkey against.");
            Modifier = modifier;
            Key = (int)key;
            hWnd = window.Handle;
            Id = GetHashCode();
            if (registerImmediately) Register();
        }

        /// <summary>
        /// Registers the current hotkey with Windows.
        /// Note! You must override the WndProc method in your window that registers the hotkey, or you will not receive any hotkey notifications.
        /// </summary>
        public void Register()
        {
            if (!NativeMethods.RegisterHotKey(hWnd, Id, (int)Modifier, Key))
                throw new GlobalHotkeyException("Hotkey failed to register.");
            registered = true;
        }

        /// <summary>
        /// Unregisters the current hotkey with Windows.
        /// </summary>
        public void Unregister()
        {
            if (!registered) return;
            if (!NativeMethods.UnregisterHotKey(hWnd, Id))
                throw new GlobalHotkeyException("Hotkey failed to unregister.");
            registered = false;
        }

        #region IDisposable Members / Finalizer

        public void Dispose()
        {
            Unregister();
            GC.SuppressFinalize(this);
        }

        ~GlobalHotkey()
        {
            Unregister();
        }

        #endregion

        #region Overrides

        public override sealed int GetHashCode()
        {
            return (int)Modifier ^ Key ^ hWnd.ToInt32();
        }

        #endregion
    }
}
