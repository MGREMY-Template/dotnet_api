using MediatR;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Identity.UserController;
using System;

namespace Shared.Core.Queries.Identity.User
{
    public class GetUserByIdQuery : IRequest<Result<UserDto>>
    {
        public Guid Id { get; set; }

        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
