using SwedbankPay.Sdk.Common;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class Payer : IdLink
    {
        public AccountInfo AccountInfo { get; set; }

        public Address BillingAddress { get; set; }

        /// <summary>
        ///     The consumer profile reference as obtained through the Consumers API.
        /// </summary>
        public string ConsumerProfileRef { get; set; }

        /// <summary>
        ///     Optional (increases chance for challenge flow if not set)
        /// </summary>

        public EmailAddress Email { get; set; }

        /// <summary>
        ///     Optional (increases chance for challenge flow if not set) If buyer is a company, use only firstName for
        ///     companyName.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///     Optional (increases chance for challenge flow if not set)
        /// </summary>
        public string HomePhoneNumber { get; set; }

        /// <summary>
        ///     Optional (increases chance for challenge flow if not set) If buyer is a company, use only firstName for
        ///     companyName.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///     Optional (increases chance for challenge flow if not set)
        /// </summary>
        public Msisdn Msisdn { get; set; }

        /// <summary>
        ///     Required when merchant onboards consumer.
        /// </summary>
        public NationalIdentifier NationalIdentifier { get; set; }

        public Address ShippingAddress { get; set; }

        /// <summary>
        ///     Optional (increases chance for challenge flow if not set)
        /// </summary>
        public string WorkPhoneNumber { get; set; }
    }
}