using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;

namespace Sheduler
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

        const string token = "1990617206:AAFDXPAOm8RvRMObS8aE4BbGwdzRB9v35Ug";
        private TelegramBotClient client = new TelegramBotClient(token);

        private long CurrentUser = 0;
        private bool isActive = false;

        private void StartButtonClick(object sender, EventArgs e)
        {
            if (!isActive)
            {
                client.StartReceiving();

                client.OnMessage += OnMessageHandler;

                Sync();
                isActive = true;
            }
        }
        int step = 0;
        private void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var action = (e.Message.Text.Split(' ').First()) switch
            {
                "/inline" => onStart(e)
            };

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

            WebClient webClient = new();

            //message reciever and processor
            {
                if (e.Message.Type == MessageType.Text)
                {
                    AddMsg(new MessageInfo(e.Message.Chat.Username, e.Message.Text, e.Message.MessageId, e.Message.Date), e.Message.Chat.Id);
                }
                else if (e.Message.Type == MessageType.Sticker)
                {
                    AddMsg(new MessageInfo(e.Message.Chat.Username, e.Message.Sticker.Emoji, e.Message.MessageId, e.Message.Date), e.Message.Chat.Id);
                }
                else if (e.Message.Type == MessageType.Photo)
                {
                    string response = webClient.DownloadString("https:" + $"//api.telegram.org/bot{token}/getFile?file_id=" + e.Message.Photo[e.Message.Photo.Count() - 1].FileId);

                    ApiResponse responseDeserialized = JsonConvert.DeserializeObject<ApiResponse>(response);
                    string[] text = responseDeserialized.result.file_path.Split('/');
                    AddMsg(new MessageInfo(e.Message.Chat.Username, text[1], e.Message.MessageId, e.Message.Date, "https:" + $"//api.telegram.org/file/bot{token}/" + responseDeserialized.result.file_path), e.Message.Chat.Id);

                }
                else if (e.Message.Type == MessageType.Video)
                {
                    string response = webClient.DownloadString("https:" + $"//api.telegram.org/bot{token}/getFile?file_id=" + e.Message.Video.FileId);

                    ApiResponse responseDeserialized = JsonConvert.DeserializeObject<ApiResponse>(response);
                    string[] text = responseDeserialized.result.file_path.Split('/');
                    AddMsg(new MessageInfo(e.Message.Chat.Username, text[1], e.Message.MessageId, e.Message.Date, "https:" + $"//api.telegram.org/file/bot{token}/" + responseDeserialized.result.file_path), e.Message.Chat.Id);

                }
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

                UpdateMsg(true);
            }
        }

        string filePath = "";

        private async void SendButtonClick(object sender, EventArgs e)
        {
            if (filePath == null)
            {
                await client.SendTextMessageAsync(CurrentUser, sendTextBox.Text);

                AddMsg(new MessageInfo("BOT", sendTextBox.Text, messages.Count, DateTime.Now), CurrentUser);
                sendTextBox.Clear();
                UpdateMsg(false);
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

                AddMsg(new MessageInfo("BOT", Path.GetFileName(filePath), messages.Count, DateTime.Now), CurrentUser);
                sendTextBox.Clear();
                UpdateMsg(false);
            }
        }

        private void sendTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendButtonClick(this, new EventArgs());
            }
        }

        private async void Sync()
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

                UpdateMsg(false);

                await Task.Delay(10);
            }
        }

        private void UpdateMsg(bool state)
        {
            if (state == false)
            {
                for (int i = 0; i < messages.Count; i++)
                {
                    if (messages[i].Id == CurrentUser)
                    {
                        if (messages[i].messages.Count > ListBoxMessages.Items.Count)
                        {
                            ListBoxMessages.Items.Add(messages[i].messages[messages[i].messages.Count - 1].Username + ": " + messages[i].messages[messages[i].messages.Count - 1].Text);
                        }
                    }
                }
            }
            else
            {
                ListBoxMessages.Items.Clear();
                for (int i = 0; i < messages.Count; i++)
                {
                    if (messages[i].Id == CurrentUser)
                    {
                        foreach (MessageInfo msg in messages[i].messages)
                        {
                            ListBoxMessages.Items.Add(msg.Username + ": " + msg.Text);
                        }
                    }
                }
            }
        }

        private void AddMsg(MessageInfo msginf, long CU)
        {
            if (messages.Count == 0)
            {
                messages.Add(new Message(CU, msginf));
            }
            else
            {
                bool containing = false;
                for (int i = 0; i < messages.Count; i++)
                {
                    if (messages.Count != 0 && messages[i].Id == CU)
                    {
                        messages[i].messages.Add(msginf);
                        containing = true;
                        break;
                    }
                }
                if (!containing)
                {
                    messages.Add(new Message(CU, msginf));
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

        private void ListBoxMessages_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ListBoxMessages.SelectedItem != null)
            {
                var msge = messages.Where(msg => msg.Id == CurrentUser).ToList();
                if (isValidateLink(msge[0].messages[ListBoxMessages.SelectedIndex].URI))
                {
                    System.Diagnostics.Process.Start(msge[0].messages[ListBoxMessages.SelectedIndex].URI);
                }
            }
        }
        private bool isValidateLink(string link)
        {
            return Uri.TryCreate(link, UriKind.Absolute, out Uri uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        private async bool onStart(MessageEventArgs e)
        {
            await
            return true;
        }
    }
}