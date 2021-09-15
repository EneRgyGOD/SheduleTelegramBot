
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ListBoxUsers = new System.Windows.Forms.ListBox();
            this.sendTextBox = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.ListBoxMessages = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start Listening";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.StartButtonClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 64);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 46);
            this.button2.TabIndex = 1;
            this.button2.Text = "Stop Listening";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.StopButtonClick);
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
            this.sendTextBox.Size = new System.Drawing.Size(226, 22);
            this.sendTextBox.TabIndex = 3;
            this.sendTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sendTextBox_KeyDown);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(522, 168);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(56, 24);
            this.button3.TabIndex = 4;
            this.button3.Text = "Send";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.SendButtonClick);
            // 
            // ListViewMessages
            // 
            this.ListBoxMessages.FormattingEnabled = true;
            this.ListBoxMessages.ItemHeight = 16;
            this.ListBoxMessages.Location = new System.Drawing.Point(290, 12);
            this.ListBoxMessages.Name = "ListViewMessages";
            this.ListBoxMessages.Size = new System.Drawing.Size(295, 148);
            this.ListBoxMessages.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 205);
            this.Controls.Add(this.ListBoxMessages);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.sendTextBox);
            this.Controls.Add(this.ListBoxUsers);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox ListBoxUsers;
        private System.Windows.Forms.TextBox sendTextBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox ListBoxMessages;
    }
}

