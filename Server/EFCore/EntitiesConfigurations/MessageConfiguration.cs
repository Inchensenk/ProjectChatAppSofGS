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
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            /*
            builder.HasKey(a => a.Id);

            builder.HasOne(c => c.Conversation).WithMany(m => m.MessageListinc);
            */

            builder.HasKey(message => message.Id);/*PrimaryKey*/

            builder.Property(message => message.MessageText)
                   .IsRequired();/*MessageText IS NOT NULL*/

            builder.HasOne(message => message.FromUser)
                   .WithMany(user => user.SendMessagesListinc)
                   .HasForeignKey(message => message.FromUserId)
                   .IsRequired();/*Отношение 1 ко многим, IS NOT NULL*/

            builder.HasOne(message => message.Conversation)
                   .WithMany(conversation => conversation.MessageListinc)
                   .HasForeignKey(message => message.ConversationId)
                   .IsRequired();

            builder.Property(message => message.IsRead)
                   .IsRequired()
                   .HasDefaultValue(false);/*статус не может быть пустой и значение по умолчанию у статуса false (то есть по умолчанию сообщение непрочитанно)*/

            builder.Property(message => message.DateTime)
                   .IsRequired();/*информация о времени отправки сообщения не может быть пустой*/
        }
    }
}
