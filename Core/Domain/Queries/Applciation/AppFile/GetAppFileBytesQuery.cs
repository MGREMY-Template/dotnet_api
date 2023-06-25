namespace Domain.Queries.Applciation.AppFile;

using Domain.DataTransferObject;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

public class GetAppFileBytesQuery : IRequest<Result<byte[]>>
{
    [Required] public Guid AppFileId { get; set; }
}
