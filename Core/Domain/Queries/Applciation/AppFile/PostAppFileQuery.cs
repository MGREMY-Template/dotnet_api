namespace Domain.Queries.Applciation.AppFile;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Application;
using MediatR;
using Microsoft.AspNetCore.Http;

public class PostAppFileQuery : IRequest<Result<AppFileDto>>
{
    public IFormFile File { get; set; }
}
