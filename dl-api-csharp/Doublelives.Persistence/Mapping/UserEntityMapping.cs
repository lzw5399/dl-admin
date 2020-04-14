using Doublelives.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doublelives.Persistence.Mapping
{
    public class UserEntityMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(c => c.Id);

            builder.HasIndex(it => it.Name);
            builder.HasIndex(it => it.Password);
            builder.HasIndex(it => it.Role);
            builder.HasIndex(it => it.Email);
        }
    }
}
