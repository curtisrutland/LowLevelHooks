using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using LowLevelHooks.Keyboard;
using LowLevelHooks.Mouse;
using LowLevelHooks.Test.Properties;

namespace LowLevelHooks.Test
{
    public partial class Form1 : Form
    {
        private readonly KeyboardHook kHook;
        private readonly MouseHook mHook;
        private bool capturingKeys;
        private bool capturingMouse;

        private static string KeyFilePath { get { return ConfigurationManager.AppSettings["keyboardWriterPath"]; } }
        private static string MouseFilePath { get { return ConfigurationManager.AppSettings["mouseWriterPath"]; } }

        private TextWriter mouseWriter;
        private TextWriter MouseWriter
        {
            get { return mouseWriter ?? (mouseWriter = TextWriter.Synchronized(new StreamWriter(MouseFilePath, true))); }
        }

        private TextWriter keyboardWriter;
        private TextWriter KeyboardWriter
        {
            get { return keyboardWriter ?? (keyboardWriter = TextWriter.Synchronized(new StreamWriter(KeyFilePath, true))); }
        }

        public Form1()
        {
            InitializeComponent();
            kHook = new KeyboardHook();
            mHook = new MouseHook();
            kHook.KeyEvent += KHookKeyEvent;
            mHook.MouseEvent += MHookMouseEvent;
            FormClosing += Form1FormClosing;
        }

        void Form1FormClosing(object sender, FormClosingEventArgs e)
        {
            kHook.Dispose();
            mHook.Dispose();
            if (mouseWriter != null)
            {
                mouseWriter.Dispose();
            }
            if (keyboardWriter != null)
            {
                keyboardWriter.Dispose();
            }
        }

        void MHookMouseEvent(object sender, MouseHookEventArgs e)
        {
            WriteMouse(e);
        }

        private void WriteMouse(MouseHookEventArgs e)
        {
            if (e.MouseEventName == MouseEventNames.MouseWheel)
            {
                MouseWriter.Write("{3} : {0}, Direction: {1}{2}", e.MouseEventName, e.ScrollDirection, Environment.NewLine, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            }
            else
            {
                MouseWriter.Write("{4} : {0}: ({1},{2}){3}", e.MouseEventName, e.Position.X, e.Position.Y, Environment.NewLine, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            }
        }

        void KHookKeyEvent(object sender, KeyboardHookEventArgs e)
        {
            WriteKey(e);
        }

        private void WriteKey(KeyboardHookEventArgs e)
        {
            if (e.Char == '\0')
            {
                KeyboardWriter.Write(e.KeyString);
            }
            else
            {
                if (e.KeyboardEventName == KeyboardEventNames.KeyUp)
                    KeyboardWriter.Write(e.KeyString);
            }
        }

        private void CaptureKeysButtonClick(object sender, EventArgs e)
        {
            if(capturingKeys)
            {
                captureKeysButton.Text = Resources.CaptureKeysString;
                clearKeyLogButton.Enabled = true;
                kHook.Unhook();
                KeyboardWriter.Flush();
            }
            else
            {
                captureKeysButton.Text = Resources.StopCapturingKeysString;
                clearKeyLogButton.Enabled = false;
                kHook.Hook();
            }
            capturingKeys = !capturingKeys;
        }

        private void CaptureMouseButtonClick(object sender, EventArgs e)
        {
            if (capturingMouse)
            {
                captureMouseButton.Text = Resources.CaptureMouseString;
                clearMouseLogButton.Enabled = true;
                mHook.Unhook();
                MouseWriter.Flush();
            }
            else
            {
                captureMouseButton.Text = Resources.StopCapturingMouseString;
                clearMouseLogButton.Enabled = false;
                mHook.Hook();
            }
            capturingMouse = !capturingMouse;
        }

        private void ClearKeyLogButtonClick(object sender, EventArgs e)
        {
            if (keyboardWriter != null)
            {
                keyboardWriter.Dispose();
                keyboardWriter = null;
            }
            File.Delete(KeyFilePath);
        }

        private void ClearMouseLogButtonClick(object sender, EventArgs e)
        {
            if(mouseWriter != null)
            {
                mouseWriter.Dispose();
                mouseWriter = null;
            }
            File.Delete(MouseFilePath);
        }

        private void OpenKeyFileButtonClick(object sender, EventArgs e)
        {
            if (File.Exists(KeyFilePath))
                Process.Start(KeyFilePath);
            else MessageBox.Show(Resources.NoFileString);
        }

        private void OpenMouseFileButtonClick(object sender, EventArgs e)
        {
            if (File.Exists(MouseFilePath))
                Process.Start(MouseFilePath);
            else MessageBox.Show(Resources.NoFileString);
        }
    }
}
