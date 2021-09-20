using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace SheduleTelegramBot
{
    public partial class Form1 : Form
    {
        UserManager userManager = new UserManager();
        List<User> users = new List<User>();
        List<Message> messages = new List<Message>();

        public Form1()
        {
            InitializeComponent();
            users = userManager.Load();
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
                users.Add(userManager.Add(e.Message.Chat.Username, e.Message.Chat.Id));
                userManager.Save(users);
            }
            else
            {
                int stableCount = users.Count;
                for (int i = 0; i < stableCount; i++)
                {
                    if (users.Any(x => x.Id != e.Message.Chat.Id))
                    {
                        users.Add(userManager.Add(e.Message.Chat.Username, e.Message.Chat.Id));
                        userManager.Save(users);
                    }

                }
            }

            messages.Add(new Message(e.Message.Chat.Id, e.Message.Chat.Username, e.Message.Text, e.Message.MessageId, e.Message.Date));
        }

        private void StopButtonClick(object sender, EventArgs e)
        {
            client.StopReceiving();
            isActive = false;
        }

        private void ChangedTargetUser(object sender, System.EventArgs et)
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

        private void SendButtonClick(object sender, System.EventArgs e)
        {
            client.SendTextMessageAsync(CurrentUser, sendTextBox.Text);

            messages.Add(new Message(CurrentUser, "BOT", sendTextBox.Text, messages.Count, DateTime.Now));
            sendTextBox.Clear();
            UpdateMsg();
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
                    string final = message.time.Hour + ":" + message.time.Minute + ":" + message.time.Second + ":" + message.time.Millisecond + "\t" + message.Username + ": " + message.Text;

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
                    ListBoxMessages.Items.Add(message.time.Hour + ":" + message.time.Minute + ":" + message.time.Second + ":" + message.time.Millisecond + "\t" + message.Username + ": " + message.Text);
                }
            }
        }
    }
}