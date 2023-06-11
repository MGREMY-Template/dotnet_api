namespace Application.Handlers.Identity.UserClaim;

using Domain.Interface;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Domain.Queries.Identity.UserClaim;
using Microsoft.EntityFrameworkCore;

public class GetCountUserClaimQueryHandler : IRequestHandler<GetUserClaimCountQuery, long>
{
    private readonly IAppDbContext _context;

    public GetCountUserClaimQueryHandler(
        IAppDbContext context)
    {
        this._context = context;
    }

    public async Task<long> Handle(GetUserClaimCountQuery request, CancellationToken cancellationToken)
    {
        return await this._context.UserClaims.LongCountAsync(cancellationToken);
    }
}
