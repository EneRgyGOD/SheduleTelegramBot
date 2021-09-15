using System;
using System.Collections.Generic;
using System.Text;
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

        private TelegramBotClient client = new TelegramBotClient("1990617206:AAFDXPAOm8RvRMObS8aE4BbGwdzRB9v35Ug");

        private long CurrentUser = 0;

        private void StartButtonClick(object sender, EventArgs e)
        {
            client.StartReceiving();
            Console.WriteLine("not gut");
            client.OnMessage += OnMessageHandler;
            Console.WriteLine("gut");

        }

        private void OnMessageHandler(object sender, MessageEventArgs e)
        {
            if (e.Message.Text == "bruh")
            {
                client.SendTextMessageAsync(e.Message.Chat.Id, "moment");
            }

            if (!users.Contains(new User(e.Message.Chat.Username, e.Message.Chat.Id)))
            {
                users.Add(userManager.Add(e.Message.Chat.Username, e.Message.Chat.Id));
                userManager.Save(users);
            }
        }

        private void StopButtonClick(object sender, EventArgs e)
        {
            client.StopReceiving();
        }

        private void ChangedTargetUser(object sender, System.EventArgs et)
        {

            string targetedName = ListBoxUsers.SelectedItem.ToString();

            for(int i = 0; i < users.Count; i++)
            {
                if( targetedName == users[i].Name)
                {
                    CurrentUser = users[i].Id;
                }
            }
        }

        private void SendButtonClick(object sender, System.EventArgs e)
        {
            client.SendTextMessageAsync(CurrentUser, sendTextBox.Text);
            for (int i = 0; i < users.Count; i++)
            {
                if (!ListBoxUsers.Items.Contains(users[i].Name))
                {
                    ListBoxUsers.Items.Add(users[i].Name);
                }
            }
        }
    }
}


