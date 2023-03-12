using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Identity.UserController;
using Shared.Core.Queries.Identity.User;
using Shared.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API.Controllers.Identity
{
    [Route("api/Identity/[controller]")]
    public class UserController : GenericController
    {
        private readonly IMediator _mediator;

        public UserController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(nameof(GetAll))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<IEnumerable<UserDto>>>> GetAll(
            CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(new GetUserAllQuery(), cancellationToken);
        }

        [HttpGet(nameof(GetList))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<IEnumerable<UserDto>>>> GetList(
            [FromQuery] BasePaging paging,
            CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(new GetUserListQuery(paging), cancellationToken);
        }

        [HttpGet(nameof(GetById))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Result<UserDto>>> GetById(
            [FromQuery] Guid id,
            CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(new GetUserByIdQuery(id), cancellationToken);
        }
    }
}
