using System.Text.Json;

namespace SwedbankPay.Sdk.Tests.Json;

public class CustomUriConverterTests
{
    private readonly string _idstring = "/psp/creditcard/payments/5adc265f-f87f-4313-577e-08d3dca1a26c";


    [Fact]
    public void CanDeSerialize_Uri()
    {
        //ARRANGE

        var jsonObject = $"{{ \"id\": \"{_idstring}\" }}";

        //ACT
        var result = JsonSerializer.Deserialize<DummyClass>(jsonObject, JsonSerialization.JsonSerialization.Settings);

        //ASSERT
        Assert.Equal(_idstring, result?.Id?.OriginalString);
    }


    [Fact]
    public void CanSerialize_Uri()
    {
        //ARRANGE
        var dummy = new DummyClass
        {
            Id = new Uri(_idstring, UriKind.RelativeOrAbsolute)
        };

        //ACT
        var result = JsonSerializer.Serialize(dummy, JsonSerialization.JsonSerialization.Settings);
        var obj = JsonDocument.Parse(result);

        var id = obj.RootElement.GetProperty("id").ToString();
        //ASSERT
        Assert.Equal(_idstring, id);
    }


    private class DummyClass
    {
        public Uri? Id { get; set; }
    }
}