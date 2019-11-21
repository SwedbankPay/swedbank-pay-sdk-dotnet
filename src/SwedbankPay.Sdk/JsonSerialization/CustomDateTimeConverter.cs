namespace SwedbankPay.Sdk.JsonSerialization
{
    using Newtonsoft.Json.Converters;

    public class CustomDateTimeConverter : IsoDateTimeConverter
    {
        public CustomDateTimeConverter()
        {
            base.DateTimeFormat = "yyyyMMdd";
        }
    }
}