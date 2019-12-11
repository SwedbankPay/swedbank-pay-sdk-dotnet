#region License

// --------------------------------------------------
// Copyright © Swedbank Pay. All Rights Reserved.
// 
// This software is proprietary information of Swedbank Pay.
// USE IS SUBJECT TO LICENSE TERMS.
// --------------------------------------------------

#endregion

using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using SwedbankPay.Sdk.Tests.TestBuilders;

using Xunit;

namespace SwedbankPay.Sdk.Tests.Json
{
    public class CustomLanguageConverterTests
    {
        private readonly string languageCode = "sv-SE";


        [Fact]
        public void CanDeSerialize_LanguageCode()
        {
            //ARRANGE

            var jsonObject = new JObject { { "language", this.languageCode } };

            //ACT
            var result = JsonConvert.DeserializeObject<Language>(jsonObject.ToString(), JsonSerialization.JsonSerialization.Settings);

            //ASSERT
            Assert.Equal(this.languageCode, result.ToString());
        }


        [Fact]
        public void CanSerialize_LanguageCode()
        {
            //ARRANGE
            var builder = new PaymentOrderRequestBuilder();
            var paymentOrderRequest = builder.WithTestValues().WithLanguageCode(this.languageCode).Build();

            //ACT
            var result = JsonConvert.SerializeObject(paymentOrderRequest, JsonSerialization.JsonSerialization.Settings);
            var obj = JObject.Parse(result);
            obj.TryGetValue("Language", StringComparison.InvariantCultureIgnoreCase, out var code);
            //ASSERT
            Assert.Equal(this.languageCode, code);
        }
    }
}