using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.EFCore.Entities
{
    public class Authorization
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }

        public Authorization()
        {
            Login= null!;
            Password= null!;
        }
    }
}
