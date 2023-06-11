namespace Application.Handlers.Identity.User;

using Domain.Interface;
using Domain.Queries.Identity.User;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

public class GetCountUserQueryHandler : IRequestHandler<GetUserCountQuery, long>
{
    private readonly IAppDbContext _context;

    public GetCountUserQueryHandler(
        IAppDbContext context)
    {
        this._context = context;
    }

    public async Task<long> Handle(GetUserCountQuery request, CancellationToken cancellationToken)
    {
        return await this._context.Roles.LongCountAsync(cancellationToken);
    }
}
