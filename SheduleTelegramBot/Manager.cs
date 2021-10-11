using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System;

namespace SheduleTelegramBot
{
    class Manager
    {

        DateTime date = DateTime.Now;

        public List<User> LoadUsers()
        {
            List<User> users = new List<User>();

            if (File.Exists("userList.txt"))
            {
                string input = File.ReadAllText("userList.txt");
                users = JsonConvert.DeserializeObject<List<User>>(input);
            }

            return users;
        }

        public bool SaveUsers(List<User> users)
        {
            string output = JsonConvert.SerializeObject(users);
            try
            {
                File.WriteAllText("userList.txt", output, Encoding.UTF8);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public User Add(string name, long id)
        {
            User user = new User(name, id);
            return user;
        }

        public bool Compare(List<User> users, long Id)
        {
            foreach (User user in users)
            {
                if (user.Id == Id) return true;
            }

            return false;
        }

        public bool SaveMessages(List<Message> messages)
        {
            try
            {
                if (!Directory.Exists("Message logs"))
                {
                    Directory.CreateDirectory("Message logs");
                }


                string path = "Message logs\\" + date.Date.ToString("yyyy.MM.dd HH:mm") + " Message log.txt";

                if (File.Exists(path))
                {
                    File.AppendAllText(path, JsonConvert.SerializeObject(messages), Encoding.UTF8);
                }
                else
                {
                    File.WriteAllText(path, JsonConvert.SerializeObject(messages), Encoding.UTF8);
                }


                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}