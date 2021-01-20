using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    internal class SwishPayment : ISwishPayment
    {
        public SwishPayment(SwishPaymentDto payment)
        {
            Number = payment.Number;
            Created = payment.Created;
            Updated = payment.Updated;
            Instrument = Enum.Parse<Sdk.PaymentInstrument>(payment.Instrument);
            Operation = payment.Operation;
            Intent = Enum.Parse<PaymentIntent>(payment.Intent);
            State = payment.State;
            Currency = new Currency(payment.Currency);
            Prices = payment.Prices.Map();
            Amount = payment.Amount;
            VatAmount = payment.VatAmount;
            RemainingCancellationAmount = payment.RemainingCancellationAmount;
            RemainingCaptureAmount = payment.RemainingCaptureAmount;
            RemainingReversalAmount = payment.RemainingReversalAmount;
            Description = payment.Description;
            PayerReference = payment.PayerReference;
            InitiatingSystemUserAgent = payment.InitiatingSystemUserAgent;
            UserAgent = payment.UserAgent;
            Language = new Language(payment.Language);
            Urls = payment.Urls.Map();
            PayeeInfo = payment.PayeeInfo.Map();
            Id = payment.Id;
            Metadata = payment.Metadata?.Map();

            Transactions = payment.Transactions?.Map();
            Sales = payment.Sales?.Map();
            Reversals = payment.Reversals?.Map();
            Cancellations = payment.Cancellations?.Map();
            Captures = payment.Captures?.Map();
        }

        public long Number { get; }
        public DateTime Created { get; }
        public DateTime Updated { get; }
        public Sdk.PaymentInstrument Instrument { get; }
        public Operation Operation { get; }
        public PaymentIntent Intent { get; }
        public State State { get; }
        public Currency Currency { get; }
        public IPricesListResponse Prices { get; }
        public Amount Amount { get; }
        public Amount RemainingReversalAmount { get; set; }
        public string Description { get; }
        public string PayerReference { get; }
        public string InitiatingSystemUserAgent { get; }
        public string UserAgent { get; }
        public Language Language { get; }
        public ITransactionListResponse Transactions { get; }
        public ISwishSaleListResponse Sales { get; }
        public IReversalsListResponse Reversals { get; }
        public IUrls Urls { get; }
        public PayeeInfo PayeeInfo { get; }
        public Uri Id { get; }
        public Metadata Metadata { get; }

        public ICancellationsListResponse Cancellations { get; }

        public ICapturesListResponse Captures { get; }

        public Amount RemainingCancellationAmount { get; }

        public Amount RemainingCaptureAmount { get; }

        public Amount VatAmount { get; }
    }
}