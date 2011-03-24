using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LowLevelHooks.Keyboard;
using LowLevelHooks.Mouse;

namespace LowLevelHooks.Test {
    public partial class Form1 : Form {

        KeyboardHook kHook;
        MouseHook mHook;

        public Form1() {
            InitializeComponent();
            kHook = new KeyboardHook();
            mHook = new MouseHook();
            kHook.KeyEvent += new EventHandler<KeyboardHookEventArgs>(kHook_KeyEvent);
            mHook.MouseEvent += new EventHandler<MouseHookEventArgs>(mHook_MouseEvent);
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }

        void mHook_MouseEvent(object sender, MouseHookEventArgs e) {
            if (e.MouseEventName == MouseEventNames.MouseWheel) {
                mouseTextBox.Text += string.Format("{0}, Direction: {1}{2}", e.MouseEventName.ToString(), e.ScrollDirection.ToString(), Environment.NewLine);
            }
            else {
                mouseTextBox.Text += string.Format("{0}: ({1},{2}){3}", e.MouseEventName.ToString(), e.Position.X, e.Position.Y, Environment.NewLine);
            }
            mouseTextBox.Select(mouseTextBox.TextLength - 1, 0);
            mouseTextBox.ScrollToCaret();
        }

        void kHook_KeyEvent(object sender, KeyboardHookEventArgs e) {
            if (e.Char == '\0') {
                keyboardTextBox.Text += e.KeyString;
            }
            else {
                if (e.KeyboardEventName == KeyboardEventNames.KeyUp)
                    keyboardTextBox.Text += e.KeyString;
            }
            if (mouseTextBox.TextLength - 1 >= 0) {
                keyboardTextBox.Select(mouseTextBox.TextLength - 1, 0);
                keyboardTextBox.ScrollToCaret();
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            kHook.Hook();
            mHook.Hook();
        }

        void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            kHook.Dispose();
            mHook.Dispose();
        }
    }
}
