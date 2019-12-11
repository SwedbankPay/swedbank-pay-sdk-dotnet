using System;

namespace SwedbankPay.Sdk.Consumers
{
    using SwedbankPay.Sdk.PaymentOrders;

    public class ConsumersRequest
    {
        public ConsumersRequest(CountryCode consumerCountryCode, Operation operation = null, Msisdn msisdn = null, EmailAddress email = null, NationalIdentifier nationalIdentifier = null)
        {
            Operation = operation ?? Operation.Initiate;
            ConsumerCountryCode = consumerCountryCode;
            Msisdn = msisdn;
            Email = email;
            NationalIdentifier = nationalIdentifier;
        }

        /// <summary>
        /// the operation to perform.
        /// </summary>
        public Operation Operation { get; }

        /// <summary>
        /// The MSISDN (mobile phone number) of the payer. Format Sweden: +46707777777. Format Norway: +4799999999.
        /// </summary>
        public Msisdn Msisdn { get; }

        /// <summary>
        /// The e-mail address of the payer.
        /// </summary>
        public EmailAddress Email { get; }

        /// <summary>
        /// Consumers country of residence. Used by the consumerUi for validation on all input fields.
        /// </summary>
        public CountryCode ConsumerCountryCode { get; }

        public NationalIdentifier NationalIdentifier { get; }
    }
}
