using System.Text.Json.Serialization;

namespace TestmonitorProject.Models;

public record CreatedBy
{
    [JsonPropertyName("id")]
    public int? Id { get; set; }
    [JsonPropertyName("email")]
    public string? Email { get; set; }
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}
