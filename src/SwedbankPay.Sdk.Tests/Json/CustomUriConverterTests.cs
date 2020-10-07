using System;
using System.Text.Json;

using Xunit;

namespace SwedbankPay.Sdk.Tests.Json
{
    public class CustomUriConverterTests
    {
        private readonly string idstring = "/psp/creditcard/payments/5adc265f-f87f-4313-577e-08d3dca1a26c";


        [Fact]
        public void CanDeSerialize_Uri()
        {
            //ARRANGE

            var jsonObject = $"{{ {{ \"id\": {this.idstring} }} }}";

            //ACT
            var result = JsonSerializer.Deserialize<Uri>(jsonObject, JsonSerialization.JsonSerialization.Settings);

            //ASSERT
            Assert.Equal(this.idstring, result.OriginalString);
        }


        [Fact]
        public void CanSerialize_Uri()
        {
            //ARRANGE
            var dummy = new DummyClass
            {
                Id = new Uri(this.idstring, UriKind.RelativeOrAbsolute)
            };

            //ACT
            var result = JsonSerializer.Serialize(dummy, JsonSerialization.JsonSerialization.Settings);
            var obj = JsonDocument.Parse(result);

            var id = obj.RootElement.GetProperty("Id").ToString();
            //ASSERT
            Assert.Equal(this.idstring, id);
        }
    }

    internal class DummyClass
    {
        public Uri Id { get; set; }
    }
}