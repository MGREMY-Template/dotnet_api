namespace Application.Handlers.Identity.UserRole;

using Domain.Interface;
using Domain.Queries.Identity.UserRole;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

public class GetCountUserRoleQueryHandler : IRequestHandler<GetUserRoleCountQuery, long>
{
    private readonly IAppDbContext _context;

    public GetCountUserRoleQueryHandler(
        IAppDbContext context)
    {
        this._context = context;
    }

    public async Task<long> Handle(GetUserRoleCountQuery request, CancellationToken cancellationToken)
    {
        return await this._context.UserRoles.LongCountAsync(cancellationToken);
    }
}
