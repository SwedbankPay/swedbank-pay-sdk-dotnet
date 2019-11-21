namespace SwedbankPay.Sdk.Consumers
{
    using SwedbankPay.Sdk.PaymentOrders;

    public class ConsumersRequest
    {
        public ConsumersRequest()
        {
            Operation = Operation.Initiate;
        }

        /// <summary>
        /// the operation to perform.
        /// </summary>
        public Operation Operation { get; }

        /// <summary>
        /// The MSISDN (mobile phone number) of the payer. Format Sweden: +46707777777. Format Norway: +4799999999.
        /// </summary>
        public Msisdn Msisdn { get; set; }

        /// <summary>
        /// The e-mail address of the payer.
        /// </summary>
        public EmailAddress Email { get; set; }

        /// <summary>
        /// Consumers country of residence. Used by the consumerUi for validation on all input fields.
        /// </summary>
        public CountryCode ConsumerCountryCode { get; set; }

        public NationalIdentifier NationalIdentifier { get; set; }
    }
}
