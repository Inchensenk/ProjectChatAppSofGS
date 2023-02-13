using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.EFCore.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Authorization? Authorization { get; set; }
        public List<Conversation> Conversations { get; set; }

        public User()
        {
            Conversations = new List<Conversation>();
            NickName = null!;
            PhoneNumber = null!;
            FirstName = null!;
            LastName = null!;
        }
    }
}
