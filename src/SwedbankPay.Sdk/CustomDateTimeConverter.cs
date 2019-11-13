using Newtonsoft.Json.Converters;

namespace SwedbankPay.Sdk
{
    public class CustomDateTimeConverter : IsoDateTimeConverter
    {
        public CustomDateTimeConverter()
        {
            base.DateTimeFormat = "yyyyMMdd";
        }
    }
}