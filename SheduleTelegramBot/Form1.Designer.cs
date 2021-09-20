
namespace SheduleTelegramBot
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
            this.btnStartListening = new System.Windows.Forms.Button();
            this.btnStopListening = new System.Windows.Forms.Button();
            this.ListBoxUsers = new System.Windows.Forms.ListBox();
            this.sendTextBox = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.ListBoxMessages = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnStartListening
            // 
            this.btnStartListening.Location = new System.Drawing.Point(12, 12);
            this.btnStartListening.Name = "btnStartListening";
            this.btnStartListening.Size = new System.Drawing.Size(111, 46);
            this.btnStartListening.TabIndex = 0;
            this.btnStartListening.Text = "Start Listening";
            this.btnStartListening.UseVisualStyleBackColor = true;
            this.btnStartListening.Click += new System.EventHandler(this.StartButtonClick);
            // 
            // btnStopListening
            // 
            this.btnStopListening.Location = new System.Drawing.Point(12, 64);
            this.btnStopListening.Name = "btnStopListening";
            this.btnStopListening.Size = new System.Drawing.Size(111, 46);
            this.btnStopListening.TabIndex = 1;
            this.btnStopListening.Text = "Stop Listening";
            this.btnStopListening.UseVisualStyleBackColor = true;
            this.btnStopListening.Click += new System.EventHandler(this.StopButtonClick);
            // 
            // ListBoxUsers
            // 
            this.ListBoxUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBoxUsers.FormattingEnabled = true;
            this.ListBoxUsers.ItemHeight = 16;
            this.ListBoxUsers.Location = new System.Drawing.Point(129, 12);
            this.ListBoxUsers.Name = "ListBoxUsers";
            this.ListBoxUsers.Size = new System.Drawing.Size(155, 180);
            this.ListBoxUsers.TabIndex = 2;
            this.ListBoxUsers.SelectedIndexChanged += new System.EventHandler(this.ChangedTargetUser);
            // 
            // sendTextBox
            // 
            this.sendTextBox.Location = new System.Drawing.Point(290, 170);
            this.sendTextBox.Name = "sendTextBox";
            this.sendTextBox.Size = new System.Drawing.Size(458, 22);
            this.sendTextBox.TabIndex = 3;
            this.sendTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sendTextBox_KeyDown);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(754, 170);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(56, 24);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.SendButtonClick);
            // 
            // ListBoxMessages
            // 
            this.ListBoxMessages.FormattingEnabled = true;
            this.ListBoxMessages.ItemHeight = 16;
            this.ListBoxMessages.Location = new System.Drawing.Point(290, 12);
            this.ListBoxMessages.Name = "ListBoxMessages";
            this.ListBoxMessages.Size = new System.Drawing.Size(520, 148);
            this.ListBoxMessages.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 205);
            this.Controls.Add(this.ListBoxMessages);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.sendTextBox);
            this.Controls.Add(this.ListBoxUsers);
            this.Controls.Add(this.btnStopListening);
            this.Controls.Add(this.btnStartListening);
            this.Name = "Form1";
            this.Text = "TelegramBot";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartListening;
        private System.Windows.Forms.ListBox ListBoxUsers;
        private System.Windows.Forms.TextBox sendTextBox;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnStopListening;
        private System.Windows.Forms.ListBox ListBoxMessages;
    }
}

