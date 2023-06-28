namespace Application.Handlers.Identity.UserLogin;

using Domain.Interface;
using Domain.Queries.Identity.UserLogin;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

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
        return await this._context.UserLogins.LongCountAsync(cancellationToken);
    }
}
