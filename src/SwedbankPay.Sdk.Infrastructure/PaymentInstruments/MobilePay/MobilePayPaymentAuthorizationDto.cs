using System;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    internal class MobilePayPaymentAuthorizationDto
    {
        public string AcquirerStan { get; set; }
        public string AcquirerTerminalId { get; set; }
        public DateTime AcquirerTransactionTime { get; set; }
        public string AcquirerTransactionType { get; set; }
        public string CardBrand { get; set; }
        public string CardType { get; set; }
        public string CountryCode { get; set; }
        public string ExpiryDate { get; set; }
        public string MaskedPan { get; set; }
        public string PanToken { get; set; }
        public AuthorizationTransactionDto Transaction { get; set; }
    }
}
