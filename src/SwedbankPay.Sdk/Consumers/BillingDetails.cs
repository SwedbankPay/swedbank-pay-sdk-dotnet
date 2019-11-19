namespace SwedbankPay.Sdk.Consumers
{
    public class BillingDetails
    {
        public string Email { get; protected set; }

        /// <summary>
        /// The MSISDN (mobile phone number) of the payer. Format Sweden: +46707777777. Format Norway: +4799999999.
        /// </summary>
        
        public string Msisdn { get; protected set; }

        
        public Address BillingAddress { get; protected set; }
    }
}
