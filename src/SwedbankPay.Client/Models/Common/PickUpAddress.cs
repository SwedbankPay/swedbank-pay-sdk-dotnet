namespace SwedbankPay.Client.Models.Common
{
    /// <summary>
    /// If shipIndicator set to 4, then prefil this.
    /// </summary>
    public class PickUpAddress
    {
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string CoAddress { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string CountryCode { get; set; }
    }
}