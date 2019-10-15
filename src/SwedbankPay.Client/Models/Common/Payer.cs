using SwedbankPay.Client.Models.Request;

namespace SwedbankPay.Client.Models.Common
{
    public class Payer
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
        public string HomePhoneNumber { get; set; }

        /// <summary>
        /// Optional (increases chance for challenge flow if not set)
        /// </summary>
        public string WorkPhoneNumber { get; set; }

        /// <summary>
        /// The consumer profile reference as obtained through the Consumers API.
        /// </summary>
        public string ConsumerProfileRef { get; set; }

        
        
       

        
    }
}
