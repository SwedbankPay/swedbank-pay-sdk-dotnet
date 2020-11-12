namespace SwedbankPay.Sdk.Consumers
{
    /// <summary>
    /// A payers shipping details
    /// </summary>
    public class ShippingDetails
    {
        public ShippingDetails()
        {
        }

        public ShippingDetails(EmailAddress email, Msisdn msisdn, Address shippingAddress)
        {
            Email = email;
            Msisdn = msisdn;
            ShippingAddress = shippingAddress;
        }

        /// <summary>
        /// The payers email
        /// </summary>
        public EmailAddress Email { get; }

        /// <summary>
        /// The MSISDN (mobile phone number) of the payer. Format Sweden: +46xxxxxxxxx. Format Norway: +47xxxxxxxx.
        /// </summary>
        public Msisdn Msisdn { get; }

        /// <summary>
        /// The payers shipping address
        /// </summary>
        public Address ShippingAddress { get; }
    }
}