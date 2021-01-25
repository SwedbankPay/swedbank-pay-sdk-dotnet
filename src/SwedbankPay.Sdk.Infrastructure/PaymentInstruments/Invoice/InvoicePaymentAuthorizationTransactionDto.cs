using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    internal class InvoicePaymentAuthorizationTransactionDto
    {
        public InvoicePaymentAuthorizationTransactionDto(IPaymentRequestDetails transaction)
        {
            Currency = transaction.Currency.ToString();
            Description = transaction.Description;
            GeneratePaymentToken = transaction.GeneratePaymentToken;
            GenerateRecurrenceToken = transaction.GenerateRecurrenceToken;
            Intent = transaction.Intent.ToString();
            Language = transaction.Language.ToString();
            Operation = transaction.Operation.Value;
            PayeeInfo = new PayeeInfoDto(transaction.PayeeInfo);
            PayerReference = transaction.PayerReference;
            PaymentToken = transaction.PaymentToken;
            PrefillInfo = new PrefillInfoDto(transaction.PrefillInfo);
            Prices = new List<PriceDto>();
            foreach (var item in transaction.Prices)
            {
                Prices.Add(new PriceDto(item));
            }
            Urls = new UrlsDto(transaction.Urls);
            UserAgent = transaction.UserAgent;
        }

        public string Currency { get; set; }
        public string Description { get; set; }
        public bool GeneratePaymentToken { get; set; }
        public bool GenerateRecurrenceToken { get; set; }
        public string Intent { get; set; }
        public string Language { get; set; }
        public string Operation { get; set; }
        public PayeeInfoDto PayeeInfo { get; set; }
        public string PayerReference { get; set; }
        public string PaymentToken { get; set; }
        public PrefillInfoDto PrefillInfo { get; set; }
        public List<PriceDto> Prices { get; set; }
        public UrlsDto Urls { get; set; }
        public string UserAgent { get; set; }
    }
}