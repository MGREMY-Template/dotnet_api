namespace Domain.DataTransferObject;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public record NotificationDto
{
    [DisplayName("Title")] public string Title { get; set; }
    [Required, DisplayName("Content")] public string Content { get; set; }
}
