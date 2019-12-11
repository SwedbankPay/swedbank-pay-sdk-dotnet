using Newtonsoft.Json;

using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk.Consumers
{
    public class BillingDetails
    {
        public BillingDetails()
        {
        }


        [JsonConstructor]
        public BillingDetails(EmailAddress email, Msisdn msisdn, Address billingAddress)
        {
            Email = email;
            Msisdn = msisdn;
            BillingAddress = billingAddress;
        }


        public Address BillingAddress { get; }
        public EmailAddress Email { get; }

        /// <summary>
        ///     The MSISDN (mobile phone number) of the payer. Format Sweden: +46707777777. Format Norway: +4799999999.
        /// </summary>

        public Msisdn Msisdn { get; }
    }
}