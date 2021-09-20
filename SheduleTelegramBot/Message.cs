using System;

namespace SheduleTelegramBot
{
    class Message
    {
        public long Id;
        public string Username;
        public string Text;
        public long MsgId;
        public DateTime time;

        public Message(long Id, string User, string Text, long MsgId, DateTime time)
        {
            this.Id = Id;  
            this.Username = User;
            this.Text = Text;   
            this.MsgId = MsgId;
            this.time = time;
        }
    }
}
