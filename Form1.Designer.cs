
namespace Sheduler
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
            this.btnChoseFile = new System.Windows.Forms.Button();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnStartListening
            // 
            this.btnStartListening.Location = new System.Drawing.Point(9, 10);
            this.btnStartListening.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartListening.Name = "btnStartListening";
            this.btnStartListening.Size = new System.Drawing.Size(83, 37);
            this.btnStartListening.TabIndex = 0;
            this.btnStartListening.Text = "Start Listening";
            this.btnStartListening.UseVisualStyleBackColor = true;
            this.btnStartListening.Click += new System.EventHandler(this.StartButtonClick);
            // 
            // btnStopListening
            // 
            this.btnStopListening.Location = new System.Drawing.Point(9, 52);
            this.btnStopListening.Margin = new System.Windows.Forms.Padding(2);
            this.btnStopListening.Name = "btnStopListening";
            this.btnStopListening.Size = new System.Drawing.Size(83, 37);
            this.btnStopListening.TabIndex = 1;
            this.btnStopListening.Text = "Stop Listening";
            this.btnStopListening.UseVisualStyleBackColor = true;
            this.btnStopListening.Click += new System.EventHandler(this.StopButtonClick);
            // 
            // ListBoxUsers
            // 
            this.ListBoxUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBoxUsers.FormattingEnabled = true;
            this.ListBoxUsers.Location = new System.Drawing.Point(97, 10);
            this.ListBoxUsers.Margin = new System.Windows.Forms.Padding(2);
            this.ListBoxUsers.Name = "ListBoxUsers";
            this.ListBoxUsers.Size = new System.Drawing.Size(117, 173);
            this.ListBoxUsers.TabIndex = 2;
            this.ListBoxUsers.SelectedIndexChanged += new System.EventHandler(this.ChangedTargetUser);
            // 
            // sendTextBox
            // 
            this.sendTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendTextBox.Location = new System.Drawing.Point(294, 134);
            this.sendTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.sendTextBox.Name = "sendTextBox";
            this.sendTextBox.Size = new System.Drawing.Size(559, 22);
            this.sendTextBox.TabIndex = 3;
            this.sendTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sendTextBox_KeyDown);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(857, 131);
            this.btnSend.Margin = new System.Windows.Forms.Padding(2);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(42, 28);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.SendButtonClick);
            // 
            // ListBoxMessages
            // 
            this.ListBoxMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBoxMessages.FormattingEnabled = true;
            this.ListBoxMessages.ItemHeight = 16;
            this.ListBoxMessages.Location = new System.Drawing.Point(217, 11);
            this.ListBoxMessages.Margin = new System.Windows.Forms.Padding(2);
            this.ListBoxMessages.Name = "ListBoxMessages";
            this.ListBoxMessages.Size = new System.Drawing.Size(682, 116);
            this.ListBoxMessages.TabIndex = 5;
            this.ListBoxMessages.MouseDoubleClick += ListBoxMessages_MouseDoubleClick;
            // 
            // btnChoseFile
            // 
            this.btnChoseFile.Location = new System.Drawing.Point(217, 132);
            this.btnChoseFile.Name = "btnChoseFile";
            this.btnChoseFile.Size = new System.Drawing.Size(72, 27);
            this.btnChoseFile.TabIndex = 6;
            this.btnChoseFile.Text = "Choose FIle";
            this.btnChoseFile.UseVisualStyleBackColor = true;
            this.btnChoseFile.Click += new System.EventHandler(this.ChooseFileButtonClick);
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilePath.Location = new System.Drawing.Point(219, 162);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(44, 16);
            this.lblFilePath.TabIndex = 7;
            this.lblFilePath.Text = "Status";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 191);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.btnChoseFile);
            this.Controls.Add(this.ListBoxMessages);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.sendTextBox);
            this.Controls.Add(this.ListBoxUsers);
            this.Controls.Add(this.btnStopListening);
            this.Controls.Add(this.btnStartListening);
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.Button btnChoseFile;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}