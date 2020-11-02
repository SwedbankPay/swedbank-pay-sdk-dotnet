using System;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    public class MobilePayPaymentAuthorization : IdLink, IMobilePayPaymentAuthorization
    {
        public MobilePayPaymentAuthorization(Uri id, MobilePayPaymentAuthorizationDto item)
        {
            Id = id;
            MaskedPan = item.MaskedPan;
            ExpiryDate = item.ExpiryDate;
            PanToken = item.PanToken;
            CardBrand = item.CardBrand;
            CardType = item.CardType;
            CountryCode = item.CountryCode;
            AcquirerTransactionType = item.AcquirerTransactionType;
            AcquirerStan = item.AcquirerStan;
            AcquirerTerminalId = item.AcquirerTerminalId;
            AcquirerTransactionTime = item.AcquirerTransactionTime;
            Transaction = item.Transaction.Map();
        }


        public string AcquirerStan { get; }
        public string AcquirerTerminalId { get; }
        public DateTime AcquirerTransactionTime { get; }
        public string AcquirerTransactionType { get; }
        public string CardBrand { get; }
        public string CardType { get; }
        public string CountryCode { get; }
        public string ExpiryDate { get; }
        public string MaskedPan { get; }
        public string PanToken { get; }
        public IMobilePayPaymentAuthorization Transaction { get; }
    }
}