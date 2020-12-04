using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class CardPaymentRecurPaymentDto
    {
        public CardPaymentRecurPaymentDto(CardPaymentRecurPayment payment)
        {
            Operation = payment.Operation.Value;
            Intent = payment.Intent.ToString();
            RecurrenceToken = payment.RecurrenceToken;
            Currency = payment.Currency.ToString();
            Amount = payment.Amount.InLowestMonetaryUnit;
            VatAmount = payment.VatAmount.InLowestMonetaryUnit;
            Description = payment.Description;
            UserAgent = payment.UserAgent;
            Language = payment.Language;
            Urls = new UrlsDto(payment.Urls);
            PayeeInfo = new PayeeInfoDto(payment.PayeeInfo);
            Metadata = payment.Metadata;
            // Id is reserved and not allowed to be sent to the API.
            Metadata.Remove("Id");
        }

        public string Operation { get; }

        public string Intent { get; }

        public string RecurrenceToken { get; }

        public string Currency { get; }

        public long Amount { get; }

        public long VatAmount { get; }

        public string Description { get; }

        public string UserAgent { get; }

        public Language Language { get; }

        public UrlsDto Urls { get; }

        public PayeeInfoDto PayeeInfo { get; }

        public Dictionary<string, object> Metadata { get; }
    }
}