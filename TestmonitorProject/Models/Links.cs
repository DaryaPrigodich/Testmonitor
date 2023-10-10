using System.Text.Json.Serialization;

namespace TestmonitorProject.Models;

public record Links
{
    [JsonPropertyName("show")]
    public string? Show { get; set; }
    [JsonPropertyName("select")]
    public string? Select { get; set; }
}
