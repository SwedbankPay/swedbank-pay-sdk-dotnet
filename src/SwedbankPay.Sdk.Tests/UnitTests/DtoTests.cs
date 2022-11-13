using SwedbankPay.Sdk.PaymentInstruments.Card;
using SwedbankPay.Sdk.PaymentOrders;
using System;
using System.Text.Json;
using Xunit;

namespace SwedbankPay.Sdk.Tests.UnitTests;

public class DtoTests
{
    [Theory]
    [InlineData("te st")]
    [InlineData("sets data")]
    [InlineData("test-data")]
    public void Creating_Abort_WithNotSupportedCharacters_ThrowsException(string data)
    {
        Assert.Throws<ArgumentException>(() => new PaymentOrderAbortRequest(data));
    }

    [Theory]
    [InlineData("testAbortReason")]
    [InlineData("CancelledByConsumer")]
    public void Creating_Abort_WithSupportedCharacters_DoesNotThrowException(string data)
    {
        new PaymentOrderAbortRequest(data);
    }

    [Fact]
    public void DateTime_IsCreated_WithCorrectType()
    {
        var testData = DateTime.Parse("2020-04-07T12:10:36.212828Z");
        var serialized = JsonSerializer.Serialize(testData, JsonSerialization.JsonSerialization.Settings);
        var result = JsonSerializer.Deserialize<DateTime>(serialized, JsonSerialization.JsonSerialization.Settings);
        Assert.Equal(DateTimeKind.Utc, result.Kind);
    }

    [Fact]
    public void ProblemResponse_IsCorrectlyMapped_ToProblemType()
    {
        var problemResponse = @"{
    ""id"": ""/psp/creditcard/payments/5adc265f-f87f-4313-577e-08d3dca1a26c/verifications"",
    ""verificationList"": [
    {
        ""id"": ""/psp/creditcard/payments/5e798e1d-1bab-43d5-abf0-08d8d7f3e9b6/transactions/3b22440d-1e07-4be1-f629-08d8d7f59ed4"",
        ""created"": ""2021-02-24T11:20:24.3578115Z"",
        ""updated"": ""2021-02-24T11:20:37.3802952Z"",
        ""type"": ""Verification"",
        ""state"": ""Failed"",
        ""number"": 70100681312,
        ""amount"": 0,
        ""vatAmount"": 0,
        ""description"": ""asd"",
        ""payeeReference"": ""cyrusLibrary1614165610"",
        ""failedReason"": ""CANCELED"",
        ""failedActivityName"": ""UpdateAuthentication"",
        ""isOperational"": false,
        ""problem"": {
            ""type"": ""https://api.payex.com/psp/errordetail/creditcard/3dsecureusercancelled"",
            ""title"": ""ExternalError"",
            ""status"": 403,
            ""detail"": ""Unable to complete Verification transaction, look at problem node!"",
            ""problems"": [
                {
                    ""name"": ""ExternalResponse"",
                    ""description"": ""CANCELED-UnableToCompleteAuthorization""
                }
            ]
        },
        ""operations"": []
    }
]}";
        var dto = JsonSerializer.Deserialize<VerificationListResponseDto>(problemResponse, JsonSerialization.JsonSerialization.Settings);

        var result = dto.Map();

        Assert.NotNull(result.VerificationList);
        Assert.NotNull(result.VerificationList[0].Problem);

        var problem = result.VerificationList[0].Problem;

        Assert.Equal("Unable to complete Verification transaction, look at problem node!", problem.Detail);
        Assert.Equal(403, problem.Status);
        Assert.Equal("ExternalError", problem.Title);
        Assert.Equal("https://api.payex.com/psp/errordetail/creditcard/3dsecureusercancelled", problem.Type);
        Assert.NotNull(problem.Problems);
        Assert.NotNull(problem.Problems[0]);
        var firstProblem = problem.Problems[0];

        Assert.Equal("CANCELED-UnableToCompleteAuthorization", firstProblem.Description);
        Assert.Equal("ExternalResponse", firstProblem.Name);
    }
}
