namespace Shared.Core.Interface;

using Microsoft.EntityFrameworkCore;
using Shared.Core.Entities.Identity;
using System.Threading;
using System.Threading.Tasks;

public interface IAppDbContext
{
    public int SaveChanges();
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    public DbSet<Role> Roles { get; set; }
    public DbSet<RoleClaim> RoleClaims { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserClaim> UserClaims { get; set; }
    public DbSet<UserLogin> UserLogins { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<UserToken> UserTokens { get; set; }
}
