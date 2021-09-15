using System.Collections.Generic;

namespace SheduleTelegramBot
{
    class Message
    {
        public long Id;
        public string Username;
        public string Text;
        public long MsgId;

        public Message(long Id, string User, string Text, long MsgId)
        {
            this.Id = Id;  
            this.Username = User;
            this.Text = Text;   
            this.MsgId = MsgId;
        }
    }
}
