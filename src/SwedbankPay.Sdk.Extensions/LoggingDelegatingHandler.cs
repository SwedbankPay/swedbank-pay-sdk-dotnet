using Microsoft.Extensions.Logging;
using SwedbankPay.Sdk.Exceptions;

namespace SwedbankPay.Sdk.Extensions;

public class LoggingDelegatingHandler : DelegatingHandler
{
    public LoggingDelegatingHandler(ILogger<LoggingDelegatingHandler> logger)
    {
        _logger = logger;
    }

    private readonly ILogger<LoggingDelegatingHandler> _logger;


    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        HttpResponseMessage httpResponse = null;
        try
        {
            httpResponse = await base.SendAsync(request, cancellationToken);
            return httpResponse;
        }
        catch (HttpResponseException ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            var httpResponseBody = await httpResponse!.Content.ReadAsStringAsync();
            throw new HttpResponseException(
                httpResponse,
                message: BuildErrorMessage(request, httpResponse, httpResponseBody),
                innerException: ex);
        }
    }

    private string BuildErrorMessage(HttpRequestMessage httpRequest, HttpResponseMessage httpResponse, string httpResponseBody) => $"{httpRequest.Method}: {httpRequest.RequestUri} failed with error code {httpResponse.StatusCode}. Response body: {httpResponseBody}";
}