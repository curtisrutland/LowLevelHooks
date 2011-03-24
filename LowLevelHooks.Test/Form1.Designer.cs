namespace LowLevelHooks.Test {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.keyboardTextBox = new System.Windows.Forms.TextBox();
            this.mouseTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.keyboardTextBox.Location = new System.Drawing.Point(13, 13);
            this.keyboardTextBox.Multiline = true;
            this.keyboardTextBox.Name = "textBox1";
            this.keyboardTextBox.Size = new System.Drawing.Size(261, 306);
            this.keyboardTextBox.TabIndex = 0;
            // 
            // textBox2
            // 
            this.mouseTextBox.Location = new System.Drawing.Point(280, 13);
            this.mouseTextBox.Multiline = true;
            this.mouseTextBox.Name = "textBox2";
            this.mouseTextBox.Size = new System.Drawing.Size(261, 306);
            this.mouseTextBox.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 331);
            this.Controls.Add(this.mouseTextBox);
            this.Controls.Add(this.keyboardTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox keyboardTextBox;
        private System.Windows.Forms.TextBox mouseTextBox;
    }
}

