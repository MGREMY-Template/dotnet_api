namespace Domain.DataTransferObject.Identity;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public record ClaimDto
{
    [Required, DisplayName("Issuer")] public string Issuer { get; set; }
    [Required, DisplayName("Type")] public string Type { get; set; }
    [Required, DisplayName("Value")] public string Value { get; set; }
}
