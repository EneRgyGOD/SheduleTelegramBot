using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;

namespace SheduleTelegramBot
{
    public partial class Form1 : Form
    {
        Manager mng = new Manager();
        List<User> users = new List<User>();
        List<Message> messages = new List<Message>();

        public Form1()
        {
            InitializeComponent();
            users = mng.LoadUsers();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < users.Count; i++)
            {
                ListBoxUsers.Items.Add(users[i].Name);
            }
        }

        private TelegramBotClient client = new TelegramBotClient("1990617206:AAFDXPAOm8RvRMObS8aE4BbGwdzRB9v35Ug");

        private long CurrentUser = 0;
        private bool isActive = false;

        private void StartButtonClick(object sender, EventArgs e)
        {
            if (!isActive)
            {
                client.StartReceiving();
                Console.WriteLine("not gut");
                client.OnMessage += OnMessageHandler;
                Console.WriteLine("gut");
                Update();
                isActive = true;
            }
        }

        private void OnMessageHandler(object sender, MessageEventArgs e)
        {
            if (e.Message.Text == "bruh")
            {
                client.SendTextMessageAsync(e.Message.Chat.Id, "moment");
            }

            if (users.Count == 0)
            {
                users.Add(mng.Add(e.Message.Chat.Username, e.Message.Chat.Id));

            }
            else
            {
                if (!mng.Compare(users, e.Message.Chat.Id))
                {
                    users.Add(mng.Add(e.Message.Chat.Username, e.Message.Chat.Id));
                }
            }

            if (e.Message.Type == MessageType.Text)
            {
                messages.Add(new Message(e.Message.Chat.Id, e.Message.Chat.Username, e.Message.Text, e.Message.MessageId, e.Message.Date));
            }
            else if (e.Message.Type == MessageType.Sticker)
            {
                messages.Add(new Message(e.Message.Chat.Id, e.Message.Chat.Username, e.Message.Sticker.Emoji, e.Message.MessageId, e.Message.Date));
            }
        }

        private void StopButtonClick(object sender, EventArgs e)
        {
            if (isActive)
            {
                client.StopReceiving();
                isActive = false;
            }
            else MessageBox.Show("Bot doesn't started yet");

        }

        private void ChangedTargetUser(object sender, EventArgs et)
        {
            if (ListBoxUsers.SelectedItem != null)
            {
                string targetedName = ListBoxUsers.SelectedItem.ToString();

                for (int i = 0; i < users.Count; i++)
                {
                    if (targetedName == users[i].Name)
                    {
                        CurrentUser = users[i].Id;
                    }
                }

                UpdateMsgBox();
            }
        }

        string filePath = null;

        private async void SendButtonClick(object sender, EventArgs e)
        {
            if (filePath == null)
            {
                client.SendTextMessageAsync(CurrentUser, sendTextBox.Text);

                messages.Add(new Message(CurrentUser, "BOT", sendTextBox.Text, messages.Count, DateTime.Now));
                sendTextBox.Clear();
                UpdateMsg();
            }
            else
            {
                lblFilePath.Text = "Sending FIle...";
                using (FileStream stream = File.OpenRead(filePath))
                {                  
                    InputOnlineFile inputOnlineFile = new InputOnlineFile(stream, Path.GetFileName(filePath));
                    await client.SendDocumentAsync(CurrentUser, inputOnlineFile);
                }

                lblFilePath.Text = "SUCCES!";

                messages.Add(new Message(CurrentUser, "BOT", Path.GetFileName(filePath), messages.Count, DateTime.Now));
                sendTextBox.Clear();
                UpdateMsg();
            }
        }

        private void sendTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendButtonClick(this, new EventArgs());
            }
        }

        private async void Update()
        {
            while (true)
            {
                for (int i = 0; i < users.Count; i++)
                {
                    if (!ListBoxUsers.Items.Contains(users[i].Name))
                    {
                        ListBoxUsers.Items.Add(users[i].Name);
                    }
                }

                UpdateMsg();

                await Task.Delay(10);
            }
        }

        private void UpdateMsg()
        {
            foreach (Message message in messages)
            {
                if (message.Id == CurrentUser)
                {
                    string final = message.time.Hour + ":" + message.time.Minute + ":" + message.time.Second + "\t" + message.Username + ": " + message.Text;

                    if (!ListBoxMessages.Items.Contains(final))
                    {
                        ListBoxMessages.Items.Add(final);
                    }
                }
            }
        }

        private void UpdateMsgBox()
        {
            ListBoxMessages.Items.Clear();
            foreach (Message message in messages)
            {
                if (message.Id == CurrentUser)
                {
                    ListBoxMessages.Items.Add(message.time.Hour + ":" + message.time.Minute + ":" + message.time.Second + "\t" + message.Username + ": " + message.Text);
                }
            }
        }

        private void Form1_Close(object sender, FormClosingEventArgs e)
        {
            mng.SaveUsers(users);
            mng.SaveMessages(messages);

        }

        private void ChooseFileButtonClick(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                lblFilePath.Text = Path.GetFileName(filePath);
            }
        }
    }
}