namespace Domain.Queries.Applciation.AppFile;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Application;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

public class GetAppFileByIdQuery : IRequest<Result<AppFileDto>>
{
    [Required] public Guid Id { get; set; }
}
