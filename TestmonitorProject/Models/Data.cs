using System.Text.Json.Serialization;

namespace TestmonitorProject.Models;

public record Data
{
    [JsonPropertyName("id")] 
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    [JsonPropertyName("symbol_id")] 
    public int SymbolId { get; set; }
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    [JsonPropertyName("key")]
    public string? Key { get; set; }
    [JsonPropertyName("starts_at")]
    public string? StartsAt { get; set; }
    [JsonPropertyName("ends_at")]
    public string? EndsAt { get; set; }
    [JsonPropertyName("completed_at")]
    public string? CompletedAt { get; set; }
    [JsonPropertyName("uses_messages")]
    public string? UsesMessages { get; set; }
    [JsonPropertyName("uses_requirements")]
    public string? UsesRequirements { get; set; }
    [JsonPropertyName("uses_risks")]
    public string? UsesRisks { get; set; }
    [JsonPropertyName("uses_applications")]
    public string? UsesApplications { get; set; }
    [JsonPropertyName("uses_issues")]
    public string? UsesIssues { get; set; }
    [JsonPropertyName("completed")]
    public bool Completed { get; set; }
    [JsonPropertyName("endpoints")]
    public Endpoints? Endpoints { get; set; }
    [JsonPropertyName("links")]
    public Links? Links { get; set; }
    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }
    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }
    [JsonPropertyName("deleted_at")]
    public string? DeletedAt { get; set; }
    [JsonPropertyName("created_by")]
    public CreatedBy? CreatedBy { get; set; }   
}
