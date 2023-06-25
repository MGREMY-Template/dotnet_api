namespace Domain.Queries.Applciation.AppFile;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Application;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

public class PostAppFileQuery : IRequest<Result<AppFileDto>>
{
    [Required] public IFormFile File { get; set; }
}
