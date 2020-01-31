using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

            var jsonObject = new JObject();
            jsonObject.Add("id", idstring);

            //ACT
            var result = JsonConvert.DeserializeObject<Uri>(jsonObject.ToString(), JsonSerialization.JsonSerialization.Settings);

            //ASSERT
            Assert.Equal(idstring, result.OriginalString);
        }


        [Fact]
        public void CanSerialize_Uri()
        {
            //ARRANGE
            var dummy = new DummyClass
            {
                Id = new Uri(idstring, UriKind.RelativeOrAbsolute)
            };

            //ACT
            var result = JsonConvert.SerializeObject(dummy, JsonSerialization.JsonSerialization.Settings);
            var obj = JObject.Parse(result);

            obj.TryGetValue("Id", StringComparison.InvariantCultureIgnoreCase, out var id);
            //ASSERT
            Assert.Equal(idstring, id);
        }
    }

    internal class DummyClass
    {
        public Uri Id { get; set; }
    }
}