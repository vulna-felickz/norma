﻿using EC.Norma.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EC.Norma.EF.Configuration
{
    public class PermissionTypeConfiguration : IEntityTypeConfiguration<Permission>
    {
        private string applicationKey;

        public PermissionTypeConfiguration(string applicationKey)
        {
            this.applicationKey = applicationKey;
        }

        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permissions");
            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Action).WithMany().HasForeignKey(a => a.IdAction);
            builder.HasOne(a => a.Resource).WithMany().HasForeignKey(a => a.IdResource);


            builder.HasQueryFilter(a => a.Action.Module.Application.Key == applicationKey);

            builder.HasQueryFilter(a => a.Resource.Module.Application.Key == applicationKey);

        }
    
    }
}
