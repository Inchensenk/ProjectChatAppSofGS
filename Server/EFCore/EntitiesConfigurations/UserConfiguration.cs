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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        /// <summary>
        /// Максимальная длинна пароля
        /// </summary>
        private const int MAX_LENGTH_OF_PASSWORD = 14;

        /// <summary>
        /// Максимальная длинна имени
        /// </summary>
        private const int MAX_NAME_LENGTH = 20;

        /// <summary>
        /// Длинна номера телефона
        /// </summary>
        private const int PHONE_NUMBER_LENGTH = 12;

        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasKey(user => user.Id);

            builder.Property(user => user.FirstName)
                   .HasMaxLength(MAX_NAME_LENGTH)
                   .IsRequired();

            builder.Property(user => user.PhoneNumber)
                   .HasMaxLength(PHONE_NUMBER_LENGTH)
                   .IsRequired();

            builder.HasAlternateKey(user => user.PhoneNumber);

            builder.Property(user => user.Password)
                   .HasMaxLength(MAX_LENGTH_OF_PASSWORD)
                   .IsRequired();

            builder.HasMany(user => user.ConversationListinc)
                   .WithMany(conversation => conversation.UserListinc);

            builder.HasMany(user => user.SendMessagesListinc)
                   .WithOne(message => message.FromUser);
        }
    }
}
