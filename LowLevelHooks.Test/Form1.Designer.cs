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
            this.captureKeysButton = new System.Windows.Forms.Button();
            this.captureMouseButton = new System.Windows.Forms.Button();
            this.clearKeyLogButton = new System.Windows.Forms.Button();
            this.clearMouseLogButton = new System.Windows.Forms.Button();
            this.openKeyFileButton = new System.Windows.Forms.Button();
            this.openMouseFileButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // captureKeysButton
            // 
            this.captureKeysButton.Location = new System.Drawing.Point(12, 12);
            this.captureKeysButton.Name = "captureKeysButton";
            this.captureKeysButton.Size = new System.Drawing.Size(120, 23);
            this.captureKeysButton.TabIndex = 0;
            this.captureKeysButton.Text = "Capture Keys";
            this.captureKeysButton.UseVisualStyleBackColor = true;
            this.captureKeysButton.Click += new System.EventHandler(this.CaptureKeysButtonClick);
            // 
            // captureMouseButton
            // 
            this.captureMouseButton.Location = new System.Drawing.Point(138, 12);
            this.captureMouseButton.Name = "captureMouseButton";
            this.captureMouseButton.Size = new System.Drawing.Size(120, 23);
            this.captureMouseButton.TabIndex = 0;
            this.captureMouseButton.Text = "Capture Mouse";
            this.captureMouseButton.UseVisualStyleBackColor = true;
            this.captureMouseButton.Click += new System.EventHandler(this.CaptureMouseButtonClick);
            // 
            // clearKeyLogButton
            // 
            this.clearKeyLogButton.Location = new System.Drawing.Point(12, 41);
            this.clearKeyLogButton.Name = "clearKeyLogButton";
            this.clearKeyLogButton.Size = new System.Drawing.Size(120, 23);
            this.clearKeyLogButton.TabIndex = 0;
            this.clearKeyLogButton.Text = "Delete Key File";
            this.clearKeyLogButton.UseVisualStyleBackColor = true;
            this.clearKeyLogButton.Click += new System.EventHandler(this.ClearKeyLogButtonClick);
            // 
            // clearMouseLogButton
            // 
            this.clearMouseLogButton.Location = new System.Drawing.Point(138, 41);
            this.clearMouseLogButton.Name = "clearMouseLogButton";
            this.clearMouseLogButton.Size = new System.Drawing.Size(120, 23);
            this.clearMouseLogButton.TabIndex = 0;
            this.clearMouseLogButton.Text = "Delete Mouse File";
            this.clearMouseLogButton.UseVisualStyleBackColor = true;
            this.clearMouseLogButton.Click += new System.EventHandler(this.ClearMouseLogButtonClick);
            // 
            // openKeyFileButton
            // 
            this.openKeyFileButton.Location = new System.Drawing.Point(13, 71);
            this.openKeyFileButton.Name = "openKeyFileButton";
            this.openKeyFileButton.Size = new System.Drawing.Size(119, 23);
            this.openKeyFileButton.TabIndex = 1;
            this.openKeyFileButton.Text = "Open Key File";
            this.openKeyFileButton.UseVisualStyleBackColor = true;
            this.openKeyFileButton.Click += new System.EventHandler(this.OpenKeyFileButtonClick);
            // 
            // openMouseFileButton
            // 
            this.openMouseFileButton.Location = new System.Drawing.Point(138, 71);
            this.openMouseFileButton.Name = "openMouseFileButton";
            this.openMouseFileButton.Size = new System.Drawing.Size(119, 23);
            this.openMouseFileButton.TabIndex = 1;
            this.openMouseFileButton.Text = "Open Mouse File";
            this.openMouseFileButton.UseVisualStyleBackColor = true;
            this.openMouseFileButton.Click += new System.EventHandler(this.OpenMouseFileButtonClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 108);
            this.Controls.Add(this.openMouseFileButton);
            this.Controls.Add(this.openKeyFileButton);
            this.Controls.Add(this.clearMouseLogButton);
            this.Controls.Add(this.captureMouseButton);
            this.Controls.Add(this.clearKeyLogButton);
            this.Controls.Add(this.captureKeysButton);
            this.Name = "Form1";
            this.Text = "Low Level Hook Tester";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button captureKeysButton;
        private System.Windows.Forms.Button captureMouseButton;
        private System.Windows.Forms.Button clearKeyLogButton;
        private System.Windows.Forms.Button clearMouseLogButton;
        private System.Windows.Forms.Button openKeyFileButton;
        private System.Windows.Forms.Button openMouseFileButton;

    }
}

