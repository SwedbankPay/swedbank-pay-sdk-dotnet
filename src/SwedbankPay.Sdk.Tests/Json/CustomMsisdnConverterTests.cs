using SwedbankPay.Sdk.PaymentInstruments;
using System.Text.Json;

using Xunit;

namespace SwedbankPay.Sdk.Tests.Json
{
    public class CustomMsisdnConverterTests
    {
        [Fact]
        public void CanDeSerialize_Msisdn()
        {
            //ARRANGE
            var jsonObject = "{ \"msisdn\": \"+46701234567\" } ";

            //ACT
            var result = JsonSerializer.Deserialize<Msisdn>(jsonObject, JsonSerialization.JsonSerialization.Settings);

            //ASSERT
            Assert.Equal("+46701234567", result.ToString());
        }


        [Fact]
        public void CanSerialize_Msisdn()
        {
            var prefillInfo = new PrefillInfo(new Msisdn("+46701234567"));

            //ACT
            var result = JsonSerializer.Serialize(prefillInfo, JsonSerialization.JsonSerialization.Settings);
            var obj = JsonDocument.Parse(result);
            var msisdn = obj.RootElement.GetProperty("msisdn").ToString();

            //ASSERT
            Assert.Equal("+46701234567", msisdn);
        }
    }
}
