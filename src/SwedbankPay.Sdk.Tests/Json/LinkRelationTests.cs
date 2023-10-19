using System.Text.Json;

using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk.Tests.Json;


public class LinkRelationTests
{
    [Fact]
    public void A()
    {
        var linkRelation = new LinkRelation("name", "value");
        var serialize = JsonSerializer.Serialize(linkRelation);
    }

    [Fact]
    public void B()
    {
        var httpOperation = new HttpOperation(new Uri("https://www.google.com", UriKind.RelativeOrAbsolute), new LinkRelation("name", "value"), "GET", "text/html");
        var serialize = JsonSerializer.Serialize(httpOperation);
    }

    [Fact]
    public void C()
    {
        var httpOperation = new HttpOperation(new Uri("https://www.google.com", UriKind.RelativeOrAbsolute), new LinkRelation("name", "value"), "GET", "text/html");
        var operationList = new OperationList
        {
            httpOperation
        };
        
        var serialize = JsonSerializer.Serialize(operationList);
    }
    
    [Fact]
    public void D()
    {
        var httpOperation = new HttpOperation(new Uri("https://www.google.com", UriKind.RelativeOrAbsolute), new LinkRelation("name", "value"), "GET", "text/html");
        var operationList = new OperationList
        {
            httpOperation
        };
        var paymentOrderOperations = new PaymentOrderOperations(operationList, new HttpClient());
        var serialize = JsonSerializer.Serialize(paymentOrderOperations, JsonSerialization.JsonSerialization.Settings);
    }
}