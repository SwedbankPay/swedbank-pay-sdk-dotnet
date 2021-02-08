using System;
using System.Collections.Generic;
using System.Text;

namespace SwedbankPay.Sdk.Extensions
{
    public static class EnumExtensions
    {
        public static TEnum Parse<TEnum>(String value) where TEnum : struct
        {
            return (TEnum)Enum.Parse(typeof(TEnum), value);
        }
    }
}
