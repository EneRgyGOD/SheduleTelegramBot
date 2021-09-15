using System;
using System.Collections.Generic;
using System.Drawing;
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

        private void StartButtonClick(object sender, EventArgs e)
        {
            client.StartReceiving();
            Console.WriteLine("not gut");
            client.OnMessage += OnMessageHandler;
            Console.WriteLine("gut");
            Update();
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
                for (int i = 0; i < users.Count; i++)
                {

                    if (users[i].Id != e.Message.Chat.Id)
                    {
                        users.Add(userManager.Add(e.Message.Chat.Username, e.Message.Chat.Id));
                        userManager.Save(users);
                    }

                }
            }

            messages.Add(new Message(e.Message.Chat.Id, e.Message.Chat.Username, e.Message.Text, e.Message.MessageId));
        }

        private void StopButtonClick(object sender, EventArgs e)
        {
            client.StopReceiving();
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

            ListBoxMessages.Items.Clear();

            UpdateMsg();
        }

        private void SendButtonClick(object sender, System.EventArgs e)
        {
            client.SendTextMessageAsync(CurrentUser, sendTextBox.Text);

            messages.Add(new Message(CurrentUser, "BOT", sendTextBox.Text, messages.Count));
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

                await Task.Delay(1000);
            }
        }

        private void UpdateMsg()
        {
            ListBoxMessages.Items.Clear();
            foreach (Message message in messages)
            {
                if (message.Id == CurrentUser)
                {
                    ListBoxMessages.Items.Add(message.Username + ": " + message.Text);
                }
            }
        }
    }
}



