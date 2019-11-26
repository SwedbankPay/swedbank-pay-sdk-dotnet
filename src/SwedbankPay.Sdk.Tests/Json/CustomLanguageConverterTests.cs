#region License
// --------------------------------------------------
// Copyright © Swedbank Pay. All Rights Reserved.
// 
// This software is proprietary information of Swedbank Pay.
// USE IS SUBJECT TO LICENSE TERMS.
// --------------------------------------------------
#endregion

namespace SwedbankPay.Sdk.Tests.Json
{
    using System;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    using SwedbankPay.Sdk.PaymentOrders;
    using SwedbankPay.Sdk.JsonSerialization;

    using Xunit;

    public class CustomLanguageConverterTests
    {
        private string languageCode = "sv-SE";

        [Fact]
        public void CanDeSerialize_LanguageCode()
        {
            //ARRANGE

            var jsonObject = new JObject();
            jsonObject.Add("language", this.languageCode);

            //ACT
            var result = JsonConvert.DeserializeObject<Language>(jsonObject.ToString(), JsonSerialization.Settings);

            //ASSERT
            Assert.Equal(this.languageCode, result.ToString());
        }

        [Fact]
        public void CanSerialize_LanguageCode()
        {
            //ARRANGE
            var paymentOrderRequest = new PaymentOrderRequest
            {
                Language = new Language(this.languageCode)
            };

            //ACT
            var result = JsonConvert.SerializeObject(paymentOrderRequest, JsonSerialization.Settings);
            var obj = JObject.Parse(result);
            obj.TryGetValue("Language", StringComparison.InvariantCultureIgnoreCase, out var code);
            //ASSERT
            Assert.Equal(this.languageCode, code);
        }
    }
}