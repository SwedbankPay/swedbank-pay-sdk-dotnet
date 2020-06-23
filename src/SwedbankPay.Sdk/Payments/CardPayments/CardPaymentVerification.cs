using System;
using System.Collections.Generic;
using System.Text;

namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public class CardPaymentVerification : IdLink
    {
        public CardPaymentVerification(
                             string cardBrand,
                             string cardType,
                             string paymentToken,
                             string recurrenceToken,
                             string maskedPan,
                             string expiryDate,
                             string panToken,
                             CardPaymentVerificationTransaction transaction)
        {
            CardBrand = cardBrand;
            CardType = cardType;
            PaymentToken = paymentToken;
            RecurrenceToken = recurrenceToken;
            MaskedPan = maskedPan;
            ExpiryDate = expiryDate;
            PanToken = panToken;
            Transaction = transaction;
        }


        public string CardBrand { get; }
        public string CardType { get; }
        public string ExpiryDate { get; }
        public string MaskedPan { get; }
        public string PanToken { get; }
        public string PaymentToken { get; }
        public string RecurrenceToken { get; }
        public CardPaymentVerificationTransaction Transaction { get; }
    }
}
