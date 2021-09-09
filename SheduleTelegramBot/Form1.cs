using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace SheduleTelegramBot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
        private static void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            if (msg.Text == "bruh")
            {
                client.SendTextMessageAsync(e.Message.Chat.Id, "moment");
            }
            CurrentUser = e.Message.Chat.Id;

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


