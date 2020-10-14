using SwedbankPay.Sdk.Extensions;
using SwedbankPay.Sdk.Payments.SwishPayments;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments
{
    public class SwishPayment : ISwishPayment
    {
        public SwishPayment(SwishPaymentResponseDto payment)
        {
            Number = payment.Number;
            Created = payment.Created;
            Updated = payment.Updated;
            Instrument = Enum.Parse<PaymentInstrument>(payment.Instrument);
            Operation = payment.Operation;
            Intent = Enum.Parse<PaymentIntent>(payment.Intent);
            State = payment.State;
            Currency = payment.Currency;
            Prices = payment.Prices.Map();
            Amount = payment.Amount;
            RemainingReversalAmount = payment.RemainingReversalAmount;
            Description = payment.Description;
            PayerReference = payment.PayerReference;
            InitiatingSystemUserAgent = payment.InitiatingSystemUserAgent;
            UserAgent = payment.UserAgent;
            Language = payment.Language;
            Transactions = payment.Transactions.Map();
            Sales = payment.Sales.Map();
            Reversals = payment.Reversals.Map();
            Urls = payment.Urls.Map();
            PayeeInfo = payment.PayeeInfo.Map();
            Id = payment.Id;
            Metadata = payment.Metadata;
        }

        public string Number { get; }
        public DateTime Created { get; }
        public DateTime Updated { get; }
        public PaymentInstrument Instrument { get; }
        public Operation Operation { get; }
        public PaymentIntent Intent { get; }
        public State State { get; }
        public CurrencyCode Currency { get; }
        public IPricesListResponse Prices { get; }
        public Amount Amount { get; }
        public Amount RemainingReversalAmount { get; set; }
        public string Description { get; }
        public string PayerReference { get; }
        public string InitiatingSystemUserAgent { get; }
        public string UserAgent { get; }
        public CultureInfo Language { get; }
        public ITransactionListResponse Transactions { get; }
        public ISaleListResponse Sales { get; }
        public IReversalsListResponse Reversals { get; }
        public IUrls Urls { get; }
        public PayeeInfo PayeeInfo { get; }
        public Uri Id { get; }
        public MetadataResponse Metadata { get; }
    }
}