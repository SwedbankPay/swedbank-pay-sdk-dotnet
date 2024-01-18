using System.Text.Json;

using SwedbankPay.Sdk.Infrastructure;
using SwedbankPay.Sdk.Infrastructure.PaymentOrder;

namespace SwedbankPay.Sdk.Tests.Json;


public class LinkRelationTests
{
    [Fact]
    public void ShouldSerializeLinkRelation()
    {
        var linkRelation = new LinkRelation("name", "value");
        JsonSerializer.Serialize(linkRelation);
    }

    [Fact]
    public void ShouldSerializeHttpOperation()
    {
        var httpOperation = new HttpOperation(new Uri("https://www.google.com", UriKind.RelativeOrAbsolute), new LinkRelation("name", "value"), "GET", "text/html");
        JsonSerializer.Serialize(httpOperation);
    }

    [Fact]
    public void ShouldSerializeOperationList()
    {
        var httpOperation = new HttpOperation(new Uri("https://www.google.com", UriKind.RelativeOrAbsolute), new LinkRelation("name", "value"), "GET", "text/html");
        var operationList = new OperationList
        {
            httpOperation
        };
        
        JsonSerializer.Serialize(operationList);
    }
    
    
    [Fact]
    public void ShouldSerializePaymentOrderResponse()
    {
        var httpOperation = new HttpOperationDto
        {
            ContentType = "text/html",
            Href = "https://www.google.com",
            Method = "GET",
            Rel = "name"
        };

        var paymentOrderResponseDto = new PaymentOrderResponseDto
        {
            PaymentOrder = new PaymentOrderResponseItemDto
            {
                Id = "/paymentorder/assdadsasd",
                Created = DateTime.Now,
                Updated = DateTime.Now,
                Operation = "operation",
                Status = "status",
                Currency = "SEK",
                VatAmount = 100,
                Amount = 1000,
                Description = "description",
                InitiatingSystemUserAgent = "userAgent",
                Language = "sv-SE",
                AvailableInstruments = new string[] { "instrument1", "instrument2" },
                Implementation = "implementation",
                Integration = "integration",
                InstrumentMode = true,
                GuestMode = true,
            },
            Operations = [httpOperation]

        };
        var paymentOrderResponse = new PaymentOrderResponse(paymentOrderResponseDto, new HttpClient());
        JsonSerializer.Serialize(paymentOrderResponse, Infrastructure.JsonSerialization.JsonSerialization.Settings);
    }
}