namespace Domain.Queries.Identity.UserClaim;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity;
using MediatR;

public class GetUserClaimByIdQuery : IRequest<Result<UserClaimDto>>
{
    public int Id { get; set; }
}
