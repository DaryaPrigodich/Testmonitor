using System.Text.Json.Serialization;

namespace TestmonitorProject.Models;

public record Project
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("symbol_id")] 
    public int SymbolId { get; set; }
}
