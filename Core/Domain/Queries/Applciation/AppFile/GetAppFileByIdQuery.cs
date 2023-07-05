namespace Domain.Queries.Applciation.AppFile;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Application;
using MediatR;
using System;

public class GetAppFileByIdQuery : IRequest<Result<AppFileDto>>
{
    public Guid Id { get; set; }
}
