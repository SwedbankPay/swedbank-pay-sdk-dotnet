using System;

namespace SwedbankPay.Sdk.Payments.MobilePayPayments
{
    public class MobilePayPaymentAuthorization : IdLink
    {
        public MobilePayPaymentAuthorization(
                             string maskedPan,
                             string expiryDate,
                             string panToken,
                             string cardBrand,
                             string cardType,
                             string countryCode,
                             string acquirerTransactionType,
                             string acquirerStan,
                             string acquirerTerminalId,
                             DateTime acquirerTransactionTime,
                             MobilePayPaymentAuthorizationTransaction transaction)
        {

            MaskedPan = maskedPan;
            ExpiryDate = expiryDate;
            PanToken = panToken;
            CardBrand = cardBrand;
            CardType = cardType;
            CountryCode = countryCode;
            AcquirerTransactionType = acquirerTransactionType;
            AcquirerStan = acquirerStan;
            AcquirerTerminalId = acquirerTerminalId;
            AcquirerTransactionTime = acquirerTransactionTime;
            Transaction = transaction;
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
        public MobilePayPaymentAuthorizationTransaction Transaction { get; }
    }
}