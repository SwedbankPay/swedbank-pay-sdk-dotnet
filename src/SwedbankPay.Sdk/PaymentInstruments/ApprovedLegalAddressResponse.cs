using System;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class ApprovedLegalAddressResponse
    {
        public ApprovedLegalAddressResponse(Uri payment, LegalAddress approvedLegalAddress)
        {
            Payment = payment;
            ApprovedLegalAddress = approvedLegalAddress;
        }

        /// <summary>
        /// A unique <seealso cref="Uri"/> to access this resource.
        /// </summary>
        public Uri Payment { get; }

        /// <summary>
        /// Object containing the payers approved legal address.
        /// </summary>
        public LegalAddress ApprovedLegalAddress { get; }
    }
}