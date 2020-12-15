using System;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    internal class MobilePayPaymentRequestDetailsDto
    {
        public MobilePayPaymentRequestDetailsDto(MobilePayRequestData mobilePay)
        {
            ShoplogoUrl = mobilePay.ShoplogoUrl;
        }

        public Uri ShoplogoUrl { get; set; }
    }
}