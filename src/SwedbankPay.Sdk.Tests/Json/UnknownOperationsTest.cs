using Newtonsoft.Json;
using SwedbankPay.Sdk.Payments.CardPayments;
using System.Net.Http;
using Xunit;

namespace SwedbankPay.Sdk.Tests.Json
{
    public class UnknownOperationsTest
    {
        [Fact]
        public void CanDeserializeUnknownOperation()
        {
            var paymentResponse = JsonConvert.DeserializeObject<CardPaymentResponse>(TestResponse, JsonSerialization.JsonSerialization.Settings);
            Assert.NotNull(paymentResponse);
        }

        [Fact]
        public void CanAccessDeserializedUnknownOperation()
        {
            var paymentResponse = JsonConvert.DeserializeObject<CardPaymentResponse>(TestResponse, JsonSerialization.JsonSerialization.Settings);
            var operations = new CardPaymentOperations(paymentResponse.Operations, new System.Net.Http.HttpClient());
            
            Assert.Contains(operations, a => a.Key.Name.Equals(TestOperationName, System.StringComparison.OrdinalIgnoreCase));
            Assert.Contains(operations, a => a.Key.Value.Equals(TestOperationName, System.StringComparison.OrdinalIgnoreCase));
        }

        [Fact]
        public void UnknownOperation_IsDeserializedTo_LinkrelationType()
        {
            var paymentResponse = JsonConvert.DeserializeObject<CardPaymentResponse>(TestResponse, JsonSerialization.JsonSerialization.Settings);
            var operations = new CardPaymentOperations(paymentResponse.Operations, new System.Net.Http.HttpClient());
            var testLinkRelation = new LinkRelation(TestOperationName, TestOperationName);

            Assert.True(operations.ContainsKey(testLinkRelation), "Missing link relation in Operation list");

            Assert.True(operations.TryGetValue(testLinkRelation, out var httpOperation), "Missing value in operation list");

            Assert.Equal("text/html", httpOperation.ContentType);
            Assert.Equal(HttpMethod.Get, httpOperation.Method);
        }

        public static string TestOperationName = "unknown-test-operation";
        public static string TestResponse = @"{
    ""payment"": {
    },
    ""operations"": [
        {
            ""method"": ""PATCH"",
            ""href"": ""https://api.stage.payex.com/psp/creditcard/payments/07f14eae-ee4d-414d-2635-08d7b43fe32e"",
            ""rel"": ""update-payment-abort"",
            ""contentType"": ""application/json""
        },
        {
            ""method"": ""GET"",
            ""href"": ""https://ecom.stage.payex.com/creditcardv2/payments/authorize/3b33a04733abc08f9331b4eaff1f8c9af65268b93914e186f8217069fe699d71"",
            ""rel"": ""redirect-authorization"",
            ""contentType"": ""text/html""
        },
        {
            ""method"": ""GET"",
            ""href"": ""https://ecom.stage.payex.com/test"",
            ""rel"": ""unknown-test-operation"",
            ""contentType"": ""text/html""
        }
    ]
}";
    }
}
