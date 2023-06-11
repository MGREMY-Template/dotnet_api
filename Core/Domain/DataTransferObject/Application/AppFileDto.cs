namespace Domain.DataTransferObject.Application;

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;

public record AppFileDto
{
    [Required, DisplayName("Id")] public Guid Id { get; set; }
    [Required, DisplayName("Size")] public long Size { get; set; }
    [Required, DisplayName("Creation user")] public Guid UserId { get; set; }
}
