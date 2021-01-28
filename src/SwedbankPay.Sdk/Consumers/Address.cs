namespace SwedbankPay.Sdk.Consumers
{
    /// <summary>
    /// Holds details about a consumers addres.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// The name of the addressee – the receiver of the shipped goods.
        /// </summary>
        public string Addressee { get; set; }

        /// <summary>
        /// Payers city of residence
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Payers c/o address, if applicable.
        /// </summary>
        public string CoAddress { get; set; }

        /// <summary>
        /// Country Code for country of residence.
        /// </summary>
        public CountryCode CountryCode { get; set; }

        /// <summary>
        /// Payers street address
        /// </summary>
        public string StreetAddress { get; set; }

        /// <summary>
        /// Payers zip code
        /// </summary>
        public string ZipCode { get; set; }
    }
}