using System.Net;
using NUnit.Allure.Attributes;
using RestSharp;
using TestmonitorProject.Clients;
using TestmonitorProject.Models;

namespace TestmonitorProject.Services.API;

public class IssueService : IDisposable
{
    private readonly RestClientExtended _client;

    public IssueService(RestClientExtended client)
    {
        _client = client;
    }

    [AllureStep("Create issue using API endpoint")]
    public HttpStatusCode CreateIssue(Issue issue)
    {
        var request = new RestRequest("issues", Method.Post)
            .AddJsonBody(issue);

        return _client.ExecuteAsync(request).Result.StatusCode;
    }
    
    [AllureStep("Get issue using API endpoint")]
    public HttpStatusCode GetIssue(string issueId)
    {
        var request = new RestRequest("issues/{issueId}")
            .AddUrlSegment("issueId", issueId);

        return _client.ExecuteAsync(request).Result.StatusCode;
    }
    
    public void Dispose()
    {
        _client.Dispose();
        GC.SuppressFinalize(this);
    }
}
