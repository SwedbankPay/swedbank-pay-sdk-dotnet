namespace SwedbankPay.Sdk.Extensions;

public static class StringExtensions
{
    public static TEnum ParseTo<TEnum>(this string value) where TEnum : struct
    {
        return (TEnum)Enum.Parse(typeof(TEnum), value);
    }
}