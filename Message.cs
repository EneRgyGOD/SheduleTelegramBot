using System;
using System.Collections.Generic;

namespace Sheduler
{
    class Message
    {
        public long Id;
        public List<MessageInfo> messages = new List<MessageInfo>();

        public Message(long id, string User, string Text, long MsgId, DateTime time)
        {
            this.Id = id;
            messages.Add(new MessageInfo(User, Text, MsgId, time));
        }
        public Message(long id, MessageInfo msginf)
        {
            this.Id = id;
            messages.Add(msginf);
        }
        public Message(MessageInfo msginf)
        {
            messages.Add(msginf);
        }

    }
    struct MessageInfo
    {
        public string Username;
        public string Text;
        public long MsgId;
        public DateTime time;
        public string URI;

        public MessageInfo(string User, string Text, long MsgId, DateTime time, string URI)
        {
            this.Username = User;
            this.Text = Text;
            this.MsgId = MsgId;
            this.time = time;
            this.URI = URI;
        }
        public MessageInfo(string User, string Text, long MsgId, DateTime time)
        {
            this.Username = User;
            this.Text = Text;
            this.MsgId = MsgId;
            this.time = time;
            this.URI = "";
        }

    }
}