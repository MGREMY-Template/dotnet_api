namespace Application.Handlers.Identity.RoleClaim;

using Domain.Interface;
using Domain.Queries.Identity.RoleClaim;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

public class GetCountRoleClaimQueryHandler : IRequestHandler<GetRoleClaimCountQuery, long>
{
    private readonly IAppDbContext _context;

    public GetCountRoleClaimQueryHandler(
        IAppDbContext context)
    {
        this._context = context;
    }

    public async Task<long> Handle(GetRoleClaimCountQuery request, CancellationToken cancellationToken)
    {
        return await this._context.RoleClaims.LongCountAsync(cancellationToken);
    }
}
