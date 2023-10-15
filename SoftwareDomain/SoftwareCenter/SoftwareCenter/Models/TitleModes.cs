using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SoftwareCenter.Models;


public record TitleCreateModel
{
    [Required, MinLength(5), MaxLength(100)]
    [DisplayName("Software Title")]
    public string TitleName { get; set; } = "";
    [DisplayName("Published By")]
    [Required, MinLength(5), MaxLength(100)]
    public string Publisher { get; set; } = "";
    [Required]
    [DisplayName("Assign Support Tech")]
    public string SupportTech { get; set; } = "";
}