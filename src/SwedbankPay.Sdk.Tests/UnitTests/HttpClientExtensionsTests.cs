using System.Net;
using System.Text.Json;

using SwedbankPay.Sdk.Infrastructure;
using SwedbankPay.Sdk.Infrastructure.Extensions;
using SwedbankPay.Sdk.Tests.TestHelpers;

namespace SwedbankPay.Sdk.Tests.UnitTests;

public class HttpClientExtensionsTests : ResourceTestsBase
{
    private const string PaymentOrderInputValidationFailedReponse = @"{
            ""sessionId"": ""09ccd29a-7c4f-4752-9396-12100cbfecce"",
            ""type"": ""https://api.payex.com/psp/errordetail/inputerror"",
            ""title"": ""Error in input data"",
            ""status"": 400,
            ""instance"": ""http://api.externalintegration.payex.com/psp/09ccd29a-7c4f-4752-9396-12100cbfecce/captures"",
            ""detail"": ""Input validation failed, error description in problems node!"",
            ""problems"": [
                {
                    ""name"": ""Transaction.Amount"",
                    ""description"": ""Some description here""
                }
            ]
        }";

    [Fact]
    public async Task ProblemResponse_CorrectlySerialzes_WhenApiReturnsWrongStatusCode()
    {
        var handler = new FakeDelegatingHandler();
        handler.FakeResponseList.Add(new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(PaymentOrderInputValidationFailedReponse)
        });
        var uri = new Uri("http://api.externalintegration.payex.com");
        var sut = new HttpClient(handler);

        var resultDto = await sut.SendAsJsonAsync<ProblemDto>(HttpMethod.Get, uri);
        var result = resultDto?.Map();

        Assert.IsType<Problem>(result);
    }
        
    [Fact]
    public void ProblemResponse_CorrectlyDeserializes_ResponseField()
    {
        var dto = JsonSerializer.Deserialize<ProblemDto>(PaymentOrderInputValidationFailedReponse, Infrastructure.JsonSerialization.JsonSerialization.Settings);

        Assert.NotNull(dto?.Problems);
        Assert.Equal("Some description here", dto?.Problems[0]?.Description);
    }
}