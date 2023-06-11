namespace Application.Handlers.Identity.UserLogin;

using Domain.Interface;
using Domain.Queries.Identity.UserLogin;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

public class GetCountUserLoginQueryHandler : IRequestHandler<GetUserLoginCountQuery, long>
{
    private readonly IAppDbContext _context;

    public GetCountUserLoginQueryHandler(
        IAppDbContext context)
    {
        this._context = context;
    }

    public async Task<long> Handle(GetUserLoginCountQuery request, CancellationToken cancellationToken)
    {
        return await this._context.Roles.LongCountAsync(cancellationToken);
    }
}
