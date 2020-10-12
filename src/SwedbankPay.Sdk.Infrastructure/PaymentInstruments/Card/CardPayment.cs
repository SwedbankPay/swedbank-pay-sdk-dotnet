﻿using System;
using System.Globalization;
using System.Linq;
using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public class CardPayment : ICardPayment
    {
        public CardPayment(CardPaymentDto payment)
        {
            if (payment is null)
            {
                throw new ArgumentNullException(nameof(payment));
            }
            // ToDo: Fill all properties
            Amount = payment.Amount;
            RemainingCaptureAmount = payment.RemainingCaptureAmount;
            RemainingCancellationAmount = payment.RemainingCancellationAmount;
            RemainingReversalAmount = payment.RemainingReversalAmount;
            Authorizations = payment.Authorizations.Map();
            Cancellations = payment.Cancellations.Map();
            Captures = payment.Captures.Map();
            Created = payment.Created;
            Updated = payment.Updated;
            Currency = new CurrencyCode( payment.Currency);
            Description = payment.Description;
            Id = new Uri(payment.Id, UriKind.RelativeOrAbsolute);
            Instrument =  Enum.Parse<PaymentInstrument>(payment.Instrument);
            Intent = Enum.Parse<Intent>(payment.Intent);
            Language = new CultureInfo(payment.Language);
            Number = payment.Number;
            Operation = payment.Operation;
            PayeeInfo = payment.PayeeInfo.Map();
            PayerReference = payment.PayerReference;
            InitiatingSystemUserAgent = payment.InitiatingSystemUserAgent;
            Prices = payment.Prices.Map();
            Reversals = payment.Reversals.Map();
            State = payment.State;
            Transactions = payment.Transactions.Map();
            Urls = new Urls(payment.Urls);
            UserAgent = payment.UserAgent;
            Metadata = new MetadataResponse(payment.Metadata);
        }

        public Amount Amount { get; }

        public Amount RemainingCaptureAmount { get; }

        public Amount RemainingCancellationAmount { get; }

        public Amount RemainingReversalAmount { get; }

        public ICardPaymentAuthorizationListResponse Authorizations { get; }

        public ICancellationsListResponse Cancellations { get; }

        public ICapturesListResponse Captures { get; }

        public DateTime Created { get; }

        public DateTime Updated { get; }

        public CurrencyCode Currency { get; }

        public string Description { get; }

        public Uri Id { get; }

        public PaymentInstrument Instrument { get; }

        public Intent Intent { get; }

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

        public MetadataResponse Metadata { get; }
    }
}