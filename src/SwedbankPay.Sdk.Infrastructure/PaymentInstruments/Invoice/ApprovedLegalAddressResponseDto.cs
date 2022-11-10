using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice;

internal class ApprovedLegalAddressResponseDto
{
    public Uri Payment { get; set; }
    public LegalAddressDto ApprovedLegalAddress { get; set; }
}