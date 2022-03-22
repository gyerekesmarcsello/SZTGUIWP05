using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZTGUIWorkhop5.Models
{
    class Message
    {
        public Message(string name, string directmessage)
        {
            this.Name = name;
            this.DirectMessage = directmessage;
            this.localDate = DateTime.Now;
        }

        public string Name { get; set; }

        public string DirectMessage { get; set; }

        public DateTime localDate { get; set; }
    }
}
