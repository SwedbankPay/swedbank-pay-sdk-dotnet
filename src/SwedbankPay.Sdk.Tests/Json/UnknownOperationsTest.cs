using Newtonsoft.Json;
using SwedbankPay.Sdk.Payments.CardPayments;
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
            //paymentResponse.Operations["test"];
        }

        public static string TestResponse = @"{
    ""payment"": {
        ""id"": ""/psp/creditcard/payments/07f14eae-ee4d-414d-2635-08d7b43fe32e"",
        ""number"": 70100358890,
        ""created"": ""2020-02-19T07:49:05.4375875Z"",
        ""updated"": ""2020-02-19T07:49:20.2673946Z"",
        ""instrument"": ""CreditCard"",
        ""operation"": ""Purchase"",
        ""intent"": ""Authorization"",
        ""state"": ""Ready"",
        ""currency"": ""NOK"",
        ""prices"": {
            ""id"": ""/psp/creditcard/payments/07f14eae-ee4d-414d-2635-08d7b43fe32e/prices""
        },
        ""amount"": 0,
        ""description"": ""Doom & Gloom"",
        ""initiatingSystemUserAgent"": ""PostmanRuntime/7.22.0"",
        ""userAgent"": ""Mozilla/5.0 Postman"",
        ""language"": ""nb-NO"",
        ""urls"": {
            ""id"": ""/psp/creditcard/payments/07f14eae-ee4d-414d-2635-08d7b43fe32e/urls""
        },
        ""payeeInfo"": {
            ""id"": ""/psp/creditcard/payments/07f14eae-ee4d-414d-2635-08d7b43fe32e/payeeinfo""
        },
        ""metadata"": {
            ""id"": ""/psp/creditcard/payments/07f14eae-ee4d-414d-2635-08d7b43fe32e/metadata""
        }
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
