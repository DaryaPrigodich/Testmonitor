using System.Runtime.Serialization;
using Newtonsoft.Json;
using RestSharp;
using TestmonitorProject.Clients;
using TestmonitorProject.Models;

namespace TestmonitorProject.Services.API;

public class ProjectService : IDisposable
{
    private readonly RestClientExtended _client;

    public ProjectService(RestClientExtended client)
    {
        _client = client;
    }

    public  ProjectResponse CreateProject(Project project)
    {
        var request = new RestRequest("projects", Method.Post)
            .AddJsonBody(project);

        var responseJson = _client.ExecuteAsync(request).Result.Content;

        return JsonConvert.DeserializeObject<ProjectResponse>(responseJson) 
               ?? throw new SerializationException("Content response is null. Debug for more details.");
    }
    
    public void Dispose()
    {
        _client.Dispose();
        GC.SuppressFinalize(this);
    }
}
