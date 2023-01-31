using Client.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.EntitiesConfigurations
{
    public class AuthorizationConfiguration : IEntityTypeConfiguration<Authorization>
    {
        public void Configure(EntityTypeBuilder<Authorization> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasOne(u => u.User).WithOne(a => a.Authorization).HasForeignKey<Authorization>(a => a.UserId);
        }
    }
}
