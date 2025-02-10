﻿using DemoCICD.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Action = DemoCICD.Domain.Entities.Identity.Action;

namespace DemoCICD.Persistence.Configurations;

public class ActionConfiguration : IEntityTypeConfiguration<Action>
{
    public void Configure(EntityTypeBuilder<Action> builder)
    {
        builder.ToTable(TableNames.Actions);
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasMaxLength(50);
        builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
        builder.Property(x => x.IsActive).HasDefaultValue(true);
        builder.Property(x => x.SortOrder).HasDefaultValue(null);

        // Each User can have mamy Permission
        builder.HasMany(e => e.Permissions).WithOne().HasForeignKey(e => e.ActionId).IsRequired();
        // Each User can have many ActionInFunction
        builder.HasMany(e => e.ActionInFunctions).WithOne().HasForeignKey(aif => aif.ActionId).IsRequired();
    }
}