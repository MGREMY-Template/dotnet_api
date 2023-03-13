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
        [ProducesResponseType(typeof(Result<IEnumerable<UserDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(
            CancellationToken cancellationToken = default)
        {
            var query = new GetUserAllQuery();
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet(nameof(GetList))]
        [ProducesResponseType(typeof(Result<IEnumerable<UserDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetList(
            [FromQuery] BasePaging paging,
            CancellationToken cancellationToken = default)
        {
            var query = new GetUserListQuery(paging);
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet(nameof(GetById))]
        [ProducesResponseType(typeof(Result<IEnumerable<UserDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<IEnumerable<UserDto>>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
            [FromQuery] Guid id,
            CancellationToken cancellationToken = default)
        {
            var query = new GetUserByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }
    }
}
