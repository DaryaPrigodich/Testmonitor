using System.Text.Json.Serialization;

namespace TestmonitorProject.Models;

public record ProjectResponse
{
    [JsonPropertyName("data")]
    public Data Data { get; set; }
}
