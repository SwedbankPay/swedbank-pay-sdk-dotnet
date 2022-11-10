using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish;

internal class SwishPaymentSaleResponseDto
{
    public Uri Payment { get; set; }
    public SiwshPaymentSaleDto Sale { get; set; }
}