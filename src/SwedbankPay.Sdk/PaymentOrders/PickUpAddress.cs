using System.Globalization;

namespace SwedbankPay.Sdk.PaymentOrders
{
    /// <summary>
    ///     If shipIndicator set to 4, then prefil this.
    /// </summary>
    /// <see cref="RiskIndicator.ShipIndicator" />
    public class PickUpAddress
    {
        public string City { get; set; }
        public string CoAddress { get; set; }
        public RegionInfo CountryCode { get; set; }
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string ZipCode { get; set; }
    }
}