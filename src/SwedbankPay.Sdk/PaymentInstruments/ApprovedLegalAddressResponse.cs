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

        public Uri Payment { get; }
        public LegalAddress ApprovedLegalAddress { get; }
    }
}