using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Entities;
using Client.EntitiesConfigurations;

namespace Client.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages {get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Authorization> Authorizations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfiguration(new ConversationConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorizationConfiguration());
        }
    }
}
