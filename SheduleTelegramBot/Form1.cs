using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace SheduleTelegramBot
{
    public partial class Form1 : Form
    {
        UserManager userManager = new UserManager();
        List<User> users = new List<User>();

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

        private static string token { get; set; } = "1990617206:AAFDXPAOm8RvRMObS8aE4BbGwdzRB9v35Ug";
        private static TelegramBotClient client;

        private static long CurrentUser = 0;

        private void StartButtonClick(object sender, EventArgs e)
        {
            client = new TelegramBotClient(token);
            client.StartReceiving();
            client.OnMessage += OnMessageHandler;
        }
        private void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            if (msg.Text == "bruh")
            {
                client.SendTextMessageAsync(msg.Chat.Id, "moment");
            }

            if (!users.Contains(new User(msg.Chat.Username, msg.Chat.Id)))
            {
                users.Add(userManager.Add(msg.Chat.Username, msg.Chat.Id));
                ListBoxUsers.Items.Add(msg.Chat.Username);
            }
            userManager.Save(users);
        }

        private void StopButtonClick(object sender, EventArgs e)
        {
            client.StopReceiving();
        }

        private void ChangedTargetUser(object sender, System.EventArgs e)
        {

        }

        private void SendButtonClick(object sender, System.EventArgs e)
        {
            client.SendTextMessageAsync(CurrentUser, sendTextBox.Text);
        }
    }
}


