using System;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    /// <summary>
    /// Holds details about a consumers approved legal address.
    /// </summary>
    public class ApprovedLegalAddressResponse
    {
        /// <summary>
        /// Instantiates a new <seealso cref="ApprovedLegalAddressResponse"/> from the provided parameters.
        /// </summary>
        /// <param name="payment">The <seealso cref="Uri"/> to the current payment.</param>
        /// <param name="approvedLegalAddress">The payers <seealso cref="LegalAddress"/>.</param>
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