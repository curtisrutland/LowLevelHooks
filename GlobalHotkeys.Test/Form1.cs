using System;
using System.ComponentModel;
using System.Windows.Forms;
using GlobalHotkeys.Test.Properties;

namespace GlobalHotkeys.Test
{
    public partial class Form1 : Form
    {
        private GlobalHotkey ghk;

        public Form1()
        {
            InitializeComponent();
            Closing += Form1Closing;
        }

        void Form1Closing(object sender, CancelEventArgs e)
        {
            ghk.Dispose();
        }

        protected override void WndProc(ref Message m)
        {
            var hotkeyInfo = HotkeyInfo.GetFromMessage(m);
            if (hotkeyInfo != null) HotkeyProc(hotkeyInfo);
            base.WndProc(ref m);
        }

        private void HotkeyProc(HotkeyInfo hotkeyInfo)
        {
            logTextBox.Text += string.Format("{0} : Hotkey Proc! {1}, {2}{3}", DateTime.Now.ToString("hh:MM:ss.fff"),
                                             hotkeyInfo.Key, hotkeyInfo.Modifiers, Environment.NewLine);
            logTextBox.Select(logTextBox.Text.Length, 0);
            logTextBox.ScrollToCaret();
        }

        private void CheckBoxCheckedChanged(object sender, EventArgs e)
        {
            if (ReferenceEquals(sender, noModCheckBox) && noModCheckBox.Checked)
            {
                altCheckBox.Checked = false;
                ctrlCheckBox.Checked = false;
                shiftCheckBox.Checked = false;
                winCheckBox.Checked = false;
            }
            else
            {
                var checkBox = sender as CheckBox;
                if(checkBox != null && checkBox.Checked)
                {
                    noModCheckBox.Checked = false;
                }
            }
        }

        private void RegisterClick(object sender, EventArgs e)
        {
            if (ghk != null) ghk.Unregister();
            if (string.IsNullOrWhiteSpace(hotkeyTextBox.Text))
            {
                MessageBox.Show(Resources.NoHotkeyErrorMessage);
                return;
            }
            var key = (Keys)Enum.Parse(typeof(Keys), hotkeyTextBox.Text.ToUpper());
            var mod = Modifiers.NoMod;
            if (altCheckBox.Checked) mod |= Modifiers.Alt;
            if (ctrlCheckBox.Checked) mod |= Modifiers.Ctrl;
            if (shiftCheckBox.Checked) mod |= Modifiers.Shift;
            if (winCheckBox.Checked) mod |= Modifiers.Win;
            try
            {
                ghk = new GlobalHotkey(mod, key, this, true);
            }
            catch(GlobalHotkeyException exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
