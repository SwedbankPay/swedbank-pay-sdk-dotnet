namespace SwedbankPay.Sdk
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