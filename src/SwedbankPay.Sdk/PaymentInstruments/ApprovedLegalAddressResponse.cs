using System;

namespace SwedbankPay.Sdk.Payments
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