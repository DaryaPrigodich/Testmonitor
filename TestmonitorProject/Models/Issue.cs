using System.Text.Json.Serialization;

namespace TestmonitorProject.Models;

public record Issue
{
    [JsonPropertyName("project_id")]
    public int ProjectId { get; set; }
    [JsonPropertyName("name")] 
    public string Name { get; set; }
    [JsonPropertyName("description")]
    public string Description { get; set; }
    [JsonPropertyName("issue_category_id")] 
    public int IssueCategoryId { get; set; }
    [JsonPropertyName("issue_status_id")] 
    public int IssueStatusId { get; set; }
}
