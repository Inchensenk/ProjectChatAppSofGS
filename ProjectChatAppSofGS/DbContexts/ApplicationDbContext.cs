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
        private const string CONNECTION_STRING = @"Server=s-dev-01;Database=ChatAppSofDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite; MultiSubnetFailover=False";
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CONNECTION_STRING);
        }
    }
}
