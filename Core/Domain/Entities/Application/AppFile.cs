namespace Domain.Entities.Application;

using Domain.Entities;
using Domain.Entities.Identity;
using System;
using System.IO;

public class AppFile : IBaseEntity<Guid>
{
    public Guid Id { get; set; }
    public DateTime CreationDate { get; set; }
    public string MimeType { get; set; }
    public long Size { get; set; }
    public Stream Content { get; set; }
    public Guid UserId { get; set; }

    public User CreationUser { get; set; }
}
