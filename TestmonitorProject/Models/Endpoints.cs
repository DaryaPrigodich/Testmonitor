using System.Text.Json.Serialization;

namespace TestmonitorProject.Models;

public record Endpoints
{
    [JsonPropertyName("show")]
    public string Show { get; set; }
    [JsonPropertyName("update")]
    public string Update { get; set; }
    [JsonPropertyName("archive")]
    public string Archive { get; set; }
    [JsonPropertyName("unarchive")]
    public string Unarchive { get; set; }
    [JsonPropertyName("members")]
    public string Members { get; set; }
    [JsonPropertyName("non-members")]
    public string NonMembers { get; set; }
}
