namespace Application.Handlers.Identity.Role;

using Domain.Interface;
using Domain.Queries.Identity.Role;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

public class GetCountRoleQueryHandler : IRequestHandler<GetRoleCountQuery, long>
{
    private readonly IAppDbContext _context;

    public GetCountRoleQueryHandler(
        IAppDbContext context)
    {
        this._context = context;
    }

    public async Task<long> Handle(GetRoleCountQuery request, CancellationToken cancellationToken)
    {
        return await this._context.Roles.LongCountAsync(cancellationToken);
    }
}
