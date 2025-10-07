
using System.ComponentModel.DataAnnotations;

namespace vl_dotnet_backend.DTO;

public class ChangePassDto
{
    [Required]
    public string OldPassword { get; set; } = string.Empty;

    [Required]
    [MinLength(6)]
    public string NewPassword { get; set; } = string.Empty;
}
