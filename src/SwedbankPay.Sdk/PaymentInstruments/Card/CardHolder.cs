namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    /// <summary>
    /// Information about a card holder
    /// </summary>
    public class Cardholder : ICardholder
    {
        /// <summary>
        /// The card holders account info.
        /// </summary>
        public AccountInfo AccountInfo { get; set; }

        /// <summary>
        /// The card holders billing address.
        /// </summary>
        public Address BillingAddress { get; set; }

        /// <summary>
        /// The card holders email address.
        /// </summary>
        public EmailAddress Email { get; set; }

        /// <summary>
        /// The card holders first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The card holders home <seealso cref="Sdk.Msisdn"/>.
        /// </summary>
        public Msisdn HomePhoneNumber { get; set; }

        /// <summary>
        /// The card holders last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The card holders <seealso cref="Sdk.Msisdn"/>.
        /// </summary>
        public Msisdn Msisdn { get; set; }

        /// <summary>
        /// The card holders shipping <seealso cref="Address"/>.
        /// </summary>
        public Address Shippingaddress { get; set; }

        /// <summary>
        /// The card holders work <seealso cref="Sdk.Msisdn"/>.
        /// </summary>
        public Msisdn WorkPhoneNumber { get; set; }
    }
}