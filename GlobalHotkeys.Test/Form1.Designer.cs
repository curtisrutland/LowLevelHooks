namespace GlobalHotkeys.Test
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.noModCheckBox = new System.Windows.Forms.CheckBox();
            this.altCheckBox = new System.Windows.Forms.CheckBox();
            this.ctrlCheckBox = new System.Windows.Forms.CheckBox();
            this.shiftCheckBox = new System.Windows.Forms.CheckBox();
            this.winCheckBox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.hotkeyTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.logTextBox);
            this.groupBox1.Location = new System.Drawing.Point(3, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 156);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output";
            // 
            // logTextBox
            // 
            this.logTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logTextBox.Location = new System.Drawing.Point(3, 16);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(369, 137);
            this.logTextBox.TabIndex = 1;
            // 
            // noModCheckBox
            // 
            this.noModCheckBox.AutoSize = true;
            this.noModCheckBox.Location = new System.Drawing.Point(6, 12);
            this.noModCheckBox.Name = "noModCheckBox";
            this.noModCheckBox.Size = new System.Drawing.Size(64, 17);
            this.noModCheckBox.TabIndex = 1;
            this.noModCheckBox.Text = "No Mod";
            this.noModCheckBox.UseVisualStyleBackColor = true;
            this.noModCheckBox.CheckedChanged += new System.EventHandler(this.CheckBoxCheckedChanged);
            // 
            // altCheckBox
            // 
            this.altCheckBox.AutoSize = true;
            this.altCheckBox.Location = new System.Drawing.Point(6, 35);
            this.altCheckBox.Name = "altCheckBox";
            this.altCheckBox.Size = new System.Drawing.Size(38, 17);
            this.altCheckBox.TabIndex = 1;
            this.altCheckBox.Text = "Alt";
            this.altCheckBox.UseVisualStyleBackColor = true;
            this.altCheckBox.CheckedChanged += new System.EventHandler(this.CheckBoxCheckedChanged);
            // 
            // ctrlCheckBox
            // 
            this.ctrlCheckBox.AutoSize = true;
            this.ctrlCheckBox.Location = new System.Drawing.Point(6, 58);
            this.ctrlCheckBox.Name = "ctrlCheckBox";
            this.ctrlCheckBox.Size = new System.Drawing.Size(41, 17);
            this.ctrlCheckBox.TabIndex = 1;
            this.ctrlCheckBox.Text = "Ctrl";
            this.ctrlCheckBox.UseVisualStyleBackColor = true;
            this.ctrlCheckBox.CheckedChanged += new System.EventHandler(this.CheckBoxCheckedChanged);
            // 
            // shiftCheckBox
            // 
            this.shiftCheckBox.AutoSize = true;
            this.shiftCheckBox.Location = new System.Drawing.Point(76, 12);
            this.shiftCheckBox.Name = "shiftCheckBox";
            this.shiftCheckBox.Size = new System.Drawing.Size(47, 17);
            this.shiftCheckBox.TabIndex = 1;
            this.shiftCheckBox.Text = "Shift";
            this.shiftCheckBox.UseVisualStyleBackColor = true;
            this.shiftCheckBox.CheckedChanged += new System.EventHandler(this.CheckBoxCheckedChanged);
            // 
            // winCheckBox
            // 
            this.winCheckBox.AutoSize = true;
            this.winCheckBox.Location = new System.Drawing.Point(76, 35);
            this.winCheckBox.Name = "winCheckBox";
            this.winCheckBox.Size = new System.Drawing.Size(66, 17);
            this.winCheckBox.TabIndex = 1;
            this.winCheckBox.Text = "Win Key";
            this.winCheckBox.UseVisualStyleBackColor = true;
            this.winCheckBox.CheckedChanged += new System.EventHandler(this.CheckBoxCheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(194, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Register";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.RegisterClick);
            // 
            // hotkeyTextBox
            // 
            this.hotkeyTextBox.Location = new System.Drawing.Point(156, 10);
            this.hotkeyTextBox.MaxLength = 1;
            this.hotkeyTextBox.Name = "hotkeyTextBox";
            this.hotkeyTextBox.Size = new System.Drawing.Size(32, 20);
            this.hotkeyTextBox.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 248);
            this.Controls.Add(this.hotkeyTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.winCheckBox);
            this.Controls.Add(this.ctrlCheckBox);
            this.Controls.Add(this.shiftCheckBox);
            this.Controls.Add(this.altCheckBox);
            this.Controls.Add(this.noModCheckBox);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "GlobalHotkeys Test Form";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.CheckBox noModCheckBox;
        private System.Windows.Forms.CheckBox altCheckBox;
        private System.Windows.Forms.CheckBox ctrlCheckBox;
        private System.Windows.Forms.CheckBox shiftCheckBox;
        private System.Windows.Forms.CheckBox winCheckBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox hotkeyTextBox;

    }
}

