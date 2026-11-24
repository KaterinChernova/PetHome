using System.ComponentModel.DataAnnotations;

namespace PetHome.Options;

public class PostgreSqlOptions
{
    public const string SectionName = "PostgreSql";

    [Required]
    public string Host { get; set; } = "";

    [Range(1, 65535)]
    public int Port { get; set; } = 5432;

    [Required]
    public string Database { get; set; } = "";

    [Required]
    public string Username { get; set; } = "";

    [Required]
    public string Password { get; set; } = "";
}