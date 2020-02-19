using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Xunit;

namespace SwedbankPay.Sdk.Tests.Json
{
    public class UknownEnumTests
    {
        [Fact]
        public void DeserializingAUnknownEnum_DoesNotThrowAnError()
        {
            var paymentInstrument = JsonConvert.DeserializeObject<PaymentInstrument>(InvalidStringEnum, JsonSerialization.JsonSerialization.Settings);
            Assert.Equal(PaymentInstrument.Unknown, paymentInstrument);
        }

        [Theory]
        [InlineData(typeof(PaymentInstrument), "Chair")]
        [InlineData(typeof(PaymentInstrument), "Bottle")]
        [InlineData(typeof(PriceType), "Bottle")]
        public void DeserializingUnknownEnum_GivesDefaultValue(Type enumType, string value)
        {
            JsonConvert.DeserializeObject(value, enumType, JsonSerialization.JsonSerialization.Settings);
        }

        [Fact]
        public void DeserializingUnknownEnum_DoesNotThrowForAnyType()
        {
            var enums = Assembly.GetAssembly(typeof(PaymentInstrument)).GetTypes().Where(t => t.IsEnum);
            foreach (var item in enums)
            {
                var result = JsonConvert.DeserializeObject(InvalidStringEnum, item, JsonSerialization.JsonSerialization.Settings);
                Assert.True(result.ToString().Equals("Unknown", StringComparison.InvariantCultureIgnoreCase), $"The default value for {item.Name} is not the string \"Unknown\"");
            }
        }

        public static string InvalidStringEnum = @"ThisIsAVeryInvalidEnumValueForThisObject";
    }
}
