using Server.EFCore.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.EFCore.EntitiesConfigurations
{
    public class ConversationConfiguration : IEntityTypeConfiguration<Conversation>
    {
        /// <summary>
        /// Конфикурация для таблицы ConversationListinc в базе данных MSSQL
        /// </summary>
        /// <param name="builder">Билдер для конфигурации сущности Conversation</param>
        public void Configure(EntityTypeBuilder<Conversation> builder)
        {
            /*
            builder.HasKey(a => a.Id);
            builder.HasOne(u => u.UserListinc).WithMany(u => u.ConversationListinc);
            */
            
            builder.HasKey(conversation => conversation.Id);/*PrimaryKey*/

            builder.HasMany(conversation => conversation.UserListinc)
                   .WithMany(user => user.ConversationListinc);/*связь многие ко многим*/

            builder.HasMany(conversation => conversation.MessageListinc)
                   .WithOne(message => message.Conversation);/*связь многие к одному*/
        }
    }
}
