namespace Application.Handlers.Identity.UserToken;

using Domain.Interface;
using Domain.Queries.Identity.UserToken;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

public class GetCountUserTokenQueryHandler : IRequestHandler<GetUserTokenCountQuery, long>
{
    private readonly IAppDbContext _context;

    public GetCountUserTokenQueryHandler(
        IAppDbContext context)
    {
        this._context = context;
    }

    public async Task<long> Handle(GetUserTokenCountQuery request, CancellationToken cancellationToken)
    {
        return await this._context.Roles.LongCountAsync(cancellationToken);
    }
}
