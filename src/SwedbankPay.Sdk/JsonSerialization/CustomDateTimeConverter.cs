using Newtonsoft.Json.Converters;

namespace SwedbankPay.Sdk.JsonSerialization
{
    public class CustomDateTimeConverter : IsoDateTimeConverter
    {
        public CustomDateTimeConverter()
        {
            DateTimeFormat = "yyyyMMdd";
        }
    }
}