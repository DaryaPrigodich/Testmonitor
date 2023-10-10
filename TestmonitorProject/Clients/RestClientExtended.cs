using NLog;
using RestSharp;
using TestmonitorProject.Configuration;
using TestmonitorProject.Models.Enum;

namespace TestmonitorProject.Clients;

public class RestClientExtended
{
    private readonly RestClient _client;

    private readonly Logger _logger = LogManager.GetCurrentClassLogger();

    public RestClientExtended(UserType userType)
    {
        if (userType == UserType.Admin)
        {
            var options = new RestClientOptions(Configurator.AppSettings.ApiUrl ?? throw new InvalidOperationException(
                "API URL can't be null. Check your appsetting.json file."));
            _client = new RestClient(options); 
        }
        else
        {
            throw new InvalidOperationException("You don't have an access.");
        }
    }

    public async Task<RestResponse> ExecuteAsync(RestRequest request)
    {
        LogRequest(request);
        var response = await _client.ExecuteAsync(request);
        LogResponse(response);
        return response;
    }

    private void LogRequest(RestRequest request)
    {
        _logger.Debug($"{request.Method} request to : {request.Resource}");
        var body = request.Parameters.FirstOrDefault(p => p.Type == ParameterType.RequestBody)?.Value;
        
        if (body != null)
        {
            _logger.Debug($"body : {body}");
        }
    }

    private void LogResponse(RestResponse response)
    {
        if (response.ErrorException != null)
        {
            _logger.Error(
                $"Error retrieving response. Check inner details for more info. \n{response.ErrorException.Message}");
        }

        _logger.Debug($"Request finished with status code : {response.StatusCode}");
        if (!string.IsNullOrEmpty(response.Content))
        {
            _logger.Debug(response.Content);
        }
    }

    public void Dispose()
    {
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }
}
