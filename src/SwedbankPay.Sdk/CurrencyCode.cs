#region License

// --------------------------------------------------
// Copyright © Swedbank Pay. All Rights Reserved.
// 
// This software is proprietary information of Swedbank Pay.
// USE IS SUBJECT TO LICENSE TERMS.
// --------------------------------------------------

#endregion

using System;
using System.Globalization;
using System.Linq;

using Newtonsoft.Json;

namespace SwedbankPay.Sdk
{
    public class CurrencyCode
    {
        [JsonConstructor]
        public CurrencyCode(string currencyCode)
        {
            if (string.IsNullOrEmpty(currencyCode))
                throw new ArgumentNullException(nameof(currencyCode), "Currency code can't be null or empty");
            if (!IsValidCurrencyCode(currencyCode))
                throw new ArgumentException($"Invalid currency code: {currencyCode}");
            Value = currencyCode;
        }


        private string Value { get; }


        public static bool IsValidCurrencyCode(string currencyCode)
        {
            if (string.IsNullOrWhiteSpace(currencyCode))
                return false;

            var regions = CultureInfo.GetCultures(CultureTypes.AllCultures)
                .Where(c => !c.IsNeutralCulture)
                .Select(culture =>
                {
                    try
                    {
                        return new RegionInfo(culture.Name);
                    }
                    catch
                    {
                        return null;
                    }
                });

            return regions.Any(ri => ri != null && ri.ISOCurrencySymbol.Equals(currencyCode));
        }


        public override string ToString()
        {
            return Value;
        }
    }
}