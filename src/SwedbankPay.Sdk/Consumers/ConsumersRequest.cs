using SwedbankPay.Sdk.PaymentOrders;
using System.Collections.Generic;
using System.Globalization;

namespace SwedbankPay.Sdk.Consumers
{
    /// <summary>
    /// Holds details to identify a consumer when initiating a payment.
    /// </summary>
    public class ConsumersRequest
    {
        /// <summary>
        /// Constructs a new request to the Consumers API resource.
        /// </summary>
        /// <param name="language">The prefered langauge for the consumer.</param>
        public ConsumersRequest(Language language)
        {
            Operation = Operation.Initiate;
            Language = language;
        }


        /// <summary>
        ///     The e-mail address of the payer.
        /// </summary>
        public EmailAddress Email { get; set; }

        /// <summary>
        ///     Selected language to be used in Checkin. Supported values are nb-NO, sv-SE and en-US
        /// </summary>
        public Language Language { get; }

        /// <summary>
        ///     The MSISDN (mobile phone number) of the payer. Format Sweden: +46707777777. Format Norway: +4799999999.
        /// </summary>
        public Msisdn Msisdn { get; set; }

        /// <summary>
        /// The payers <seealso cref="PaymentOrders.NationalIdentifier"/>.
        /// </summary>
        public NationalIdentifier NationalIdentifier { get; set; }

        /// <summary>
        ///     the operation to perform.
        /// </summary>
        public Operation Operation { get; set; }

        /// <summary>
        ///     List of supported shipping countries for merchant. Using ISO-3166 standard.
        /// </summary>
        public List<RegionInfo> ShippingAddressRestrictedToCountryCodes { get; } = new List<RegionInfo>();
    }
}