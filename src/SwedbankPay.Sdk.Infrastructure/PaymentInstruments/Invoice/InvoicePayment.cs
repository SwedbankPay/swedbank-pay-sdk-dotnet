using SwedbankPay.Sdk.Payments.InvoicePayments;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace SwedbankPay.Sdk.Payments
{
    internal class InvoicePayment : IInvoicePayment
    {
        public InvoicePayment(InvoicePaymentDto payment)
        {
            Amount = payment.Amount;
            RemainingCaptureAmount = payment.RemainingCaptureAmount;
            RemainingCancellationAmount = payment.RemainingCancellationAmount;
            RemainingReversalAmount = payment.RemainingReversalAmount;
            Authorizations = payment.Authorizations.Map();
            Cancellations = payment.Cancellations;
            Captures = payment.Captures;
            Created = payment.Created;
            Updated = payment.Updated;
            Currency = payment.Currency;
            Description = payment.Description;
            Id = payment.Id;
            Instrument = Enum.Parse<PaymentInstrument>(payment.Instrument);
            Intent = Enum.Parse<PaymentIntent>(payment.Intent);
            Language = payment.Language;
            Number = payment.Number;
            Operation = payment.Operation;
            PayeeInfo = payment.PayeeInfo.Map();
            PayerReference = payment.PayerReference;
            InitiatingSystemUserAgent = payment.InitiatingSystemUserAgent;
            Prices = payment.Prices.Map();
            Reversals = payment.Reversals.Map();
            State = payment.State;
            Transactions = payment.Transactions;
            Urls = payment.Urls;
            UserAgent = payment.UserAgent;
            Metadata = payment.Metadata;
        }

        public Amount Amount { get; }

        public Amount RemainingCaptureAmount { get; }

        public Amount RemainingCancellationAmount { get; }

        public Amount RemainingReversalAmount { get; }

        public IInvoicePaymentAuthorizationListResponse Authorizations { get; }

        public ICancellationsListResponse Cancellations { get; }

        public ICapturesListResponse Captures { get; }

        public DateTime Created { get; }

        public DateTime Updated { get; }

        public CurrencyCode Currency { get; }

        public string Description { get; }

        public Uri Id { get; }

        public PaymentInstrument Instrument { get; }

        public PaymentIntent Intent { get; }

        public CultureInfo Language { get; }

        public string Number { get; }

        public Operation Operation { get; }

        public PayeeInfo PayeeInfo { get; }

        public string PayerReference { get; }

        public string InitiatingSystemUserAgent { get; }

        public IPricesListResponse Prices { get; }

        public IReversalsListResponse Reversals { get; }

        public State State { get; }

        public ITransactionListResponse Transactions { get; }

        public IUrls Urls { get; }

        public string UserAgent { get; }

        public Dictionary<string, object> Metadata { get; }
    }
}