namespace SwedbankPay.Sdk.Models.Common
{
    using SwedbankPay.Sdk.Models.Request;
    using SwedbankPay.Sdk.Models.Response;

    public class Payer : IdLink
    {
        /// <summary>
        /// Required when merchant onboards consumer.
        /// </summary>
        public NationalIdentifier NationalIdentifier { get; set; }

        /// <summary>
        /// Optional (increases chance for challenge flow if not set) If buyer is a company, use only firstName for companyName.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Optional (increases chance for challenge flow if not set) If buyer is a company, use only firstName for companyName.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Optional (increases chance for challenge flow if not set)
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Optional (increases chance for challenge flow if not set)
        /// </summary>
        public string Msisdn { get; set; }

        /// <summary>
        /// Optional (increases chance for challenge flow if not set)
        /// </summary>
        public string WorkPhoneNumber { get; set; }

        /// <summary>
        /// Optional (increases chance for challenge flow if not set)
        /// </summary>
        public string HomePhoneNumber { get; set; }

        public ShippingAddress ShippingAddress { get; set; }

        public BillingAddress BillingAddress { get; set; }

        /// <summary>
        /// The consumer profile reference as obtained through the Consumers API.
        /// </summary>
        public string ConsumerProfileRef { get; set; }

        
        
       

        
    }
}
