using System.ComponentModel.DataAnnotations;

namespace PetHome.Options;

public class AdoptionApplicationOptions
{
    public const string SectionName = "AdoptionApplication";

    [Required]
    public bool IsApplicationEnable { get; set; } = true;
    
    [MaxLength(100)]
    [Required]
    public string Env { get; set; } = "Development";

    public int RetryCount { get; set; } = 2;
}