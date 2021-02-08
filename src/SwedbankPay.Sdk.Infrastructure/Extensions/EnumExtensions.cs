using System;
using System.Collections.Generic;
using System.Text;

namespace SwedbankPay.Sdk.Extensions
{
    public static class StringExtensions

    {
        public static TEnum Parse<TEnum>(this string value) where TEnum : struct
        {
            return (TEnum)Enum.Parse(typeof(TEnum), value);
        }
    }
}
