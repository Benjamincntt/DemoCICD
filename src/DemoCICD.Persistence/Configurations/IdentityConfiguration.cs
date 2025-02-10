using DemoCICD.Persistence.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoCICD.Persistence.Configurations;

internal sealed class AppUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
    {
        builder.ToTable(TableNames.AppUserRoles);
        builder.HasKey(ur => new { ur.UserId, ur.RoleId });
    }
}

internal sealed class AppRoleClaimConfiguration : IEntityTypeConfiguration<IdentityRoleClaim<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityRoleClaim<Guid>> builder)
    {
        builder.ToTable(TableNames.AppRoleClaims);
        builder.HasKey(r => r.RoleId);
    }
}

internal sealed class AppUserClaimConfiguration : IEntityTypeConfiguration<IdentityUserClaim<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserClaim<Guid>> builder)
    {
        builder.ToTable(TableNames.AppUserClaims);
        builder.HasKey(r => r.UserId);
    }
}

internal sealed class AppUserLoginConfiguration : IEntityTypeConfiguration<IdentityUserLogin<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserLogin<Guid>> builder)
    {
        builder.ToTable(TableNames.AppUserLogins);
        builder.HasKey(r => r.UserId);
    }
}

internal sealed class AppUserTokenConfiguration : IEntityTypeConfiguration<IdentityUserToken<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserToken<Guid>> builder)
    {
        builder.ToTable(TableNames.AppUserTokens);
        builder.HasKey(r => r.UserId);
    }
}