namespace Application.Handlers.Identity.UserClaim;

using Domain.Interface;
using Domain.Queries.Identity.UserClaim;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

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
