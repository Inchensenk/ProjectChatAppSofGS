using Microsoft.EntityFrameworkCore;
using Server.EFCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.EFCore.EntitiesConfigurations;

namespace Server.EFCore.DatabaseServices
{
    public class ChatDbContext : DbContext
    {

        /// <summary>
        /// Строка подключения
        /// </summary>
        private const string CONNECTION_STRING = @"Data Source=s-dev-01; 
                                                 Database=ChatsDB; 
                                                 Integrated Security=True;
                                                 Connect Timeout=30;
                                                 Encrypt=False;
                                                 TrustServerCertificate=False;
                                                 ApplicationIntent=ReadWrite;
                                                 MultiSubnetFailover=False";

        /// <summary>
        /// Логгирование операций выполняемых в Entity Framework с выводом логгов в файл mylog.txt
        /// </summary>
        private readonly StreamWriter logStream = new StreamWriter("mylog.txt", true);

        /// <summary>
        /// Сопоставление обьекта класса Message с таблицой базы данных Messages
        /// </summary>
        public DbSet<Message> Messages { get; set; }

        /// <summary>
        /// Сопоставление обьекта класса User с таблицой базы данных Users
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Сопоставление обьекта класса Conversation с таблицой базы данных Conversations
        /// </summary>
        public DbSet<Conversation> Conversations { get; set; }

        /// <summary>
        /// Сопоставление обьекта класса Authorization с таблицой базы данных Authorizations
        /// </summary>
        public DbSet<Authorization> Authorizations { get; set; }



        public ChatDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CONNECTION_STRING);
        }



        /// <summary>
        /// Применение конфигураций сущностей EFCore
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfiguration(new ConversationConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorizationConfiguration());
        }

        /// <summary>
        /// Закрытие и утилизация файлового потока StreamWriter
        /// </summary>
        /// <returns>файл лога mylog.txt</returns>
        public override async ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
            await logStream.DisposeAsync();
        }
    }
}
