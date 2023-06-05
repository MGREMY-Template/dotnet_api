namespace Infrastructure.Data;

using Domain.Entities.Application;
using Domain.Entities.Identity;
using Domain.Interface;
using Infrastructure;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

public class IdentityContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>, IAppDbContext
{
    public DbSet<AppFile> AppFiles { get; set; }

    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        _ = builder.ApplyConfigurationsFromAssembly(typeof(Marker).Assembly);
    }

    public override int SaveChanges()
    {
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}
