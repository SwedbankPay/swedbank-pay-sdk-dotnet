namespace SwedbankPay.Client.Models.Common
{
    public class Payer
    {
        /// <summary>
        /// The consumer profile reference as obtained through the Consumers API.
        /// </summary>
        public string ConsumerProfileRef { get; set; }

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
    }
}
