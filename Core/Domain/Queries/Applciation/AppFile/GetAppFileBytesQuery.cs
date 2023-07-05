namespace Domain.Queries.Applciation.AppFile;

using Domain.DataTransferObject;
using MediatR;
using System;

public class GetAppFileBytesQuery : IRequest<Result<byte[]>>
{
    public Guid AppFileId { get; set; }
}
