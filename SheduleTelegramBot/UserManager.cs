using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using Telegram.Bot;
using System.Windows.Forms;
using System.Text;

namespace SheduleTelegramBot
{
    class UserManager
    {
        public List<User> Load()
        {
            List<User> users = new List<User>();

            if (File.Exists("userList.txt"))
            {
                string input = File.ReadAllText("userList.txt");
                users = JsonConvert.DeserializeObject<List<User>>(input);
            }

            return users;
        }

        public bool Save(List<User> users)
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
    }
}
