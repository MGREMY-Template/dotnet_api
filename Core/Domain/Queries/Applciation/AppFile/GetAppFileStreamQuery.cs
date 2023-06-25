namespace Domain.Queries.Applciation.AppFile;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

public class GetAppFileStreamQuery : IRequest<PhysicalFileResult>
{
    [Required] public Guid AppFileId { get; set; }
}
