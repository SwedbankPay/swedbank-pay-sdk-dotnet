namespace SwedbankPay.Sdk.Tests.Json
{
    using System;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    using SwedbankPay.Sdk.JsonSerialization;
    using SwedbankPay.Sdk.PaymentOrders;
    using SwedbankPay.Sdk.Payments;

    using Xunit;

    public class CustomUriConverterTests
    {
        private string idstring = "/psp/creditcard/payments/5adc265f-f87f-4313-577e-08d3dca1a26c";

        [Fact]
        public void CanDeSerialize_Uri()
        {
            //ARRANGE

            var jsonObject = new JObject();
            jsonObject.Add("id", this.idstring);

            //ACT
            var result = JsonConvert.DeserializeObject<Uri>(jsonObject.ToString(), JsonSerialization.Settings);

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
            var result = JsonConvert.SerializeObject(dummy, JsonSerialization.Settings);
            var obj = JObject.Parse(result);
            
            obj.TryGetValue("Id", StringComparison.InvariantCultureIgnoreCase, out var id);
            //ASSERT
            Assert.Equal(this.idstring, id);
        }
    }

    internal class DummyClass
    {
        public Uri Id { get; set; }
    }
}