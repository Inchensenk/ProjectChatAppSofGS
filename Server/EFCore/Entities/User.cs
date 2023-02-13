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
        public string NickName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public Authorization? Authorization { get; set; }
        public List<Conversation> Conversations { get; set; }

        public User()
        {
            Conversations = new List<Conversation>();
        }
    }
}
