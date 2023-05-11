namespace Domain.DataTransferObject;

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public record RoleDto
{
    [Required, DisplayName("Id")] public Guid Id { get; set; }
    [Required, DisplayName("Name")] public string Name { get; set; }

    public RoleDto(Guid id, string name)
    {
        this.Id = id;
        this.Name = name;
    }
}
