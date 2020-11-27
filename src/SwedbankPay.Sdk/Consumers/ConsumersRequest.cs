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
        /// <param name="shippingAddressRestrictedToCountryCodes">A <seealso cref="IEnumerable{RegionInfo}"/> that lists available countrys this payment will ship to.</param>
        /// <param name="operation">The initiating operation for this request.</param>
        /// <param name="msisdn">The consumers <seealso cref="Sdk.Msisdn"/>.</param>
        /// <param name="email">The consumers <seealso cref="Sdk.EmailAddress"/>.</param>
        /// <param name="nationalIdentifier">The consumers <seealso cref="Sdk.PaymentOrders.NationalIdentifier"/>.</param>
        public ConsumersRequest(Language language,
                                IEnumerable<RegionInfo> shippingAddressRestrictedToCountryCodes,
                                Operation operation = null,
                                Msisdn msisdn = null,
                                EmailAddress email = null,
                                NationalIdentifier nationalIdentifier = null)
        {
            Operation = operation ?? Operation.Initiate;
            Language = language;
            Msisdn = msisdn;
            Email = email;
            NationalIdentifier = nationalIdentifier;
            ShippingAddressRestrictedToCountryCodes = shippingAddressRestrictedToCountryCodes ?? new List<RegionInfo>();
        }


        /// <summary>
        ///     The e-mail address of the payer.
        /// </summary>
        public EmailAddress Email { get; }

        /// <summary>
        ///     Selected language to be used in Checkin. Supported values are nb-NO, sv-SE and en-US
        /// </summary>
        public Language Language { get; }

        /// <summary>
        ///     The MSISDN (mobile phone number) of the payer. Format Sweden: +46707777777. Format Norway: +4799999999.
        /// </summary>
        public Msisdn Msisdn { get; }

        /// <summary>
        /// The payers <seealso cref="Sdk.PaymentOrders.NationalIdentifier"/>.
        /// </summary>
        public NationalIdentifier NationalIdentifier { get; }

        /// <summary>
        ///     the operation to perform.
        /// </summary>
        public Operation Operation { get; }

        /// <summary>
        ///     List of supported shipping countries for merchant. Using ISO-3166 standard.
        /// </summary>
        public IEnumerable<RegionInfo> ShippingAddressRestrictedToCountryCodes { get; }
    }
}