namespace Domain.Queries.Applciation.AppFile;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Application;
using MediatR;

public class GetAppFileAllQuery : IRequest<Result<AppFileDto[]>>
{
}
