namespace ClipboardAccessorDemo
{
    partial class MainForm
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
            this.plaintextTextbox = new System.Windows.Forms.TextBox();
            this.plaintextLabel = new System.Windows.Forms.Label();
            this.rtfLabel = new System.Windows.Forms.Label();
            this.rtfTextbox = new System.Windows.Forms.RichTextBox();
            this.clipboardMonitoringGroup = new System.Windows.Forms.GroupBox();
            this.copyToClipboardButton = new System.Windows.Forms.Button();
            this.clipboardAccessorGroup = new System.Windows.Forms.GroupBox();
            this.copyToClipboardLabel = new System.Windows.Forms.Label();
            this.copyToClipboardTextbox = new System.Windows.Forms.TextBox();
            this.pasteFromClipboardButton = new System.Windows.Forms.Button();
            this.pasteFromClipboardTextbox = new System.Windows.Forms.TextBox();
            this.pasteFromClipboardLabel = new System.Windows.Forms.Label();
            this.clipboardMonitoringGroup.SuspendLayout();
            this.clipboardAccessorGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // plaintextTextbox
            // 
            this.plaintextTextbox.Location = new System.Drawing.Point(97, 40);
            this.plaintextTextbox.Multiline = true;
            this.plaintextTextbox.Name = "plaintextTextbox";
            this.plaintextTextbox.ReadOnly = true;
            this.plaintextTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.plaintextTextbox.Size = new System.Drawing.Size(330, 77);
            this.plaintextTextbox.TabIndex = 0;
            // 
            // plaintextLabel
            // 
            this.plaintextLabel.AutoSize = true;
            this.plaintextLabel.Location = new System.Drawing.Point(20, 40);
            this.plaintextLabel.Name = "plaintextLabel";
            this.plaintextLabel.Size = new System.Drawing.Size(47, 13);
            this.plaintextLabel.TabIndex = 0;
            this.plaintextLabel.Text = "Plaintext";
            // 
            // rtfLabel
            // 
            this.rtfLabel.AutoSize = true;
            this.rtfLabel.Location = new System.Drawing.Point(20, 123);
            this.rtfLabel.Name = "rtfLabel";
            this.rtfLabel.Size = new System.Drawing.Size(28, 13);
            this.rtfLabel.TabIndex = 0;
            this.rtfLabel.Text = "RTF";
            // 
            // rtfTextbox
            // 
            this.rtfTextbox.Location = new System.Drawing.Point(97, 123);
            this.rtfTextbox.Name = "rtfTextbox";
            this.rtfTextbox.ReadOnly = true;
            this.rtfTextbox.Size = new System.Drawing.Size(330, 96);
            this.rtfTextbox.TabIndex = 1;
            this.rtfTextbox.Text = "";
            // 
            // clipboardMonitoringGroup
            // 
            this.clipboardMonitoringGroup.Controls.Add(this.plaintextTextbox);
            this.clipboardMonitoringGroup.Controls.Add(this.rtfTextbox);
            this.clipboardMonitoringGroup.Controls.Add(this.plaintextLabel);
            this.clipboardMonitoringGroup.Controls.Add(this.rtfLabel);
            this.clipboardMonitoringGroup.Location = new System.Drawing.Point(12, 123);
            this.clipboardMonitoringGroup.Name = "clipboardMonitoringGroup";
            this.clipboardMonitoringGroup.Size = new System.Drawing.Size(449, 242);
            this.clipboardMonitoringGroup.TabIndex = 1;
            this.clipboardMonitoringGroup.TabStop = false;
            this.clipboardMonitoringGroup.Text = "Plaintext or RTF Clipboard Monitoring";
            // 
            // copyToClipboardButton
            // 
            this.copyToClipboardButton.Location = new System.Drawing.Point(287, 25);
            this.copyToClipboardButton.Name = "copyToClipboardButton";
            this.copyToClipboardButton.Size = new System.Drawing.Size(140, 23);
            this.copyToClipboardButton.TabIndex = 1;
            this.copyToClipboardButton.Text = "Copy to clipboard";
            this.copyToClipboardButton.UseVisualStyleBackColor = true;
            this.copyToClipboardButton.Click += new System.EventHandler(this.copyToClipboardButton_Click);
            // 
            // clipboardAccessorGroup
            // 
            this.clipboardAccessorGroup.Controls.Add(this.pasteFromClipboardButton);
            this.clipboardAccessorGroup.Controls.Add(this.pasteFromClipboardTextbox);
            this.clipboardAccessorGroup.Controls.Add(this.copyToClipboardTextbox);
            this.clipboardAccessorGroup.Controls.Add(this.pasteFromClipboardLabel);
            this.clipboardAccessorGroup.Controls.Add(this.copyToClipboardLabel);
            this.clipboardAccessorGroup.Controls.Add(this.copyToClipboardButton);
            this.clipboardAccessorGroup.Location = new System.Drawing.Point(12, 12);
            this.clipboardAccessorGroup.Name = "clipboardAccessorGroup";
            this.clipboardAccessorGroup.Size = new System.Drawing.Size(449, 96);
            this.clipboardAccessorGroup.TabIndex = 0;
            this.clipboardAccessorGroup.TabStop = false;
            this.clipboardAccessorGroup.Text = "Clipboard Accessor";
            // 
            // copyToClipboardLabel
            // 
            this.copyToClipboardLabel.AutoSize = true;
            this.copyToClipboardLabel.Location = new System.Drawing.Point(20, 30);
            this.copyToClipboardLabel.Name = "copyToClipboardLabel";
            this.copyToClipboardLabel.Size = new System.Drawing.Size(51, 13);
            this.copyToClipboardLabel.TabIndex = 5;
            this.copyToClipboardLabel.Text = "Input text";
            // 
            // copyToClipboardTextbox
            // 
            this.copyToClipboardTextbox.Location = new System.Drawing.Point(97, 27);
            this.copyToClipboardTextbox.Name = "copyToClipboardTextbox";
            this.copyToClipboardTextbox.Size = new System.Drawing.Size(184, 20);
            this.copyToClipboardTextbox.TabIndex = 0;
            // 
            // pasteFromClipboardButton
            // 
            this.pasteFromClipboardButton.Location = new System.Drawing.Point(287, 57);
            this.pasteFromClipboardButton.Name = "pasteFromClipboardButton";
            this.pasteFromClipboardButton.Size = new System.Drawing.Size(140, 23);
            this.pasteFromClipboardButton.TabIndex = 3;
            this.pasteFromClipboardButton.Text = "Paste from clipboard";
            this.pasteFromClipboardButton.UseVisualStyleBackColor = true;
            this.pasteFromClipboardButton.Click += new System.EventHandler(this.pasteFromClipboardButton_Click);
            // 
            // pasteFromClipboardTextbox
            // 
            this.pasteFromClipboardTextbox.Location = new System.Drawing.Point(97, 59);
            this.pasteFromClipboardTextbox.Name = "pasteFromClipboardTextbox";
            this.pasteFromClipboardTextbox.ReadOnly = true;
            this.pasteFromClipboardTextbox.Size = new System.Drawing.Size(184, 20);
            this.pasteFromClipboardTextbox.TabIndex = 2;
            // 
            // pasteFromClipboardLabel
            // 
            this.pasteFromClipboardLabel.AutoSize = true;
            this.pasteFromClipboardLabel.Location = new System.Drawing.Point(20, 66);
            this.pasteFromClipboardLabel.Name = "pasteFromClipboardLabel";
            this.pasteFromClipboardLabel.Size = new System.Drawing.Size(59, 13);
            this.pasteFromClipboardLabel.TabIndex = 5;
            this.pasteFromClipboardLabel.Text = "Output text";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 374);
            this.Controls.Add(this.clipboardAccessorGroup);
            this.Controls.Add(this.clipboardMonitoringGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Clipboard Accessor Demo";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.clipboardMonitoringGroup.ResumeLayout(false);
            this.clipboardMonitoringGroup.PerformLayout();
            this.clipboardAccessorGroup.ResumeLayout(false);
            this.clipboardAccessorGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox plaintextTextbox;
        private System.Windows.Forms.Label plaintextLabel;
        private System.Windows.Forms.Label rtfLabel;
        private System.Windows.Forms.RichTextBox rtfTextbox;
        private System.Windows.Forms.GroupBox clipboardMonitoringGroup;
        private System.Windows.Forms.Button copyToClipboardButton;
        private System.Windows.Forms.GroupBox clipboardAccessorGroup;
        private System.Windows.Forms.Button pasteFromClipboardButton;
        private System.Windows.Forms.TextBox pasteFromClipboardTextbox;
        private System.Windows.Forms.TextBox copyToClipboardTextbox;
        private System.Windows.Forms.Label pasteFromClipboardLabel;
        private System.Windows.Forms.Label copyToClipboardLabel;
    }
}

