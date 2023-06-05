namespace Domain.DataTransferObject.Application;

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;

public record AppFileDto
{
    [Required, DisplayName("Id")] public Guid Id { get; set; }
    [Required, DisplayName("Creation date")] public DateTime CreationDate { get; set; }
    [Required, DisplayName("Content")] public Stream Content { get; set; }
    [Required, DisplayName("Creation user")] public Guid UserId { get; set; }
}
