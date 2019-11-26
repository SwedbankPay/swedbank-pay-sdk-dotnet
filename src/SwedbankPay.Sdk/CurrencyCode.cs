#region License
// --------------------------------------------------
// Copyright © Swedbank Pay. All Rights Reserved.
// 
// This software is proprietary information of Swedbank Pay.
// USE IS SUBJECT TO LICENSE TERMS.
// --------------------------------------------------
#endregion

namespace SwedbankPay.Sdk
{
    using System;
    using System.Globalization;
    using System.Linq;

    using Newtonsoft.Json;

    public class CurrencyCode
    {
        private string Value { get; }

        [JsonConstructor]
        public CurrencyCode(string currencyCode)
        {
            if (string.IsNullOrEmpty(currencyCode))
            {
                throw new ArgumentNullException(nameof(currencyCode), $"Currency code can't be null or empty");
            }
            if (!IsValidCurrencyCode(currencyCode))
            {
                throw new ArgumentException($"Invalid currency code: {currencyCode}", nameof(currencyCode));
            }
            this.Value = currencyCode;
        }

        public static bool IsValidCurrencyCode(string currencyCode)
        {
            if (string.IsNullOrWhiteSpace(currencyCode))
            {
                return false;
            }
            
            var regions = CultureInfo.GetCultures(CultureTypes.SpecificCultures).Select(x => new RegionInfo(x.LCID));

            return regions.Any(x => x.ISOCurrencySymbol.Equals(currencyCode));
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}