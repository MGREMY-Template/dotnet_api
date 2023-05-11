﻿namespace Domain.Queries.Identity.RoleClaim;

using Domain.DataTransferObject;
using Domain.Paging;
using MediatR;
using System.ComponentModel.DataAnnotations;

public class GetRoleClaimListQuery : IRequest<Result<RoleClaimDto[]>>
{
    [Required] public IPaging Paging { get; set; }

    public GetRoleClaimListQuery(IPaging paging)
    {
        this.Paging = paging;
    }
}
