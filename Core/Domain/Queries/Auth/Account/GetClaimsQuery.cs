namespace Domain.Queries.Auth.Account;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Auth.AccountController.Output;
using MediatR;

public class GetClaimsQuery : IRequest<Result<GetClaimsOutput>>
{
}
