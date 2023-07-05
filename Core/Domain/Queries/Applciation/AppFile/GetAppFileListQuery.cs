namespace Domain.Queries.Applciation.AppFile;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Application;
using Domain.Paging;
using MediatR;

public class GetAppFileListQuery : IRequest<Result<AppFileDto[]>>
{
    public IPaging Paging { get; set; }

    public GetAppFileListQuery(IPaging paging)
    {
        this.Paging = paging;
    }
}
