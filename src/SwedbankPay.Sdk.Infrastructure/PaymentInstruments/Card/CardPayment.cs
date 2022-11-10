﻿using SwedbankPay.Sdk.Extensions;
using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class CardPayment : ICardPayment
    {
        public CardPayment(CardPaymentDto payment)
        {
            if (payment is null)
            {
                throw new ArgumentNullException(nameof(payment));
            }

            Amount = payment.Amount;
            VatAmount = payment.VatAmount;
            RemainingCaptureAmount = payment.RemainingCaptureAmount;
            RemainingCancellationAmount = payment.RemainingCancellationAmount;
            RemainingReversalAmount = payment.RemainingReversalAmount;
            Created = payment.Created;
            Updated = payment.Updated;
            Currency = new Currency(payment.Currency);
            Description = payment.Description;
            Id = new Uri(payment.Id, UriKind.RelativeOrAbsolute);
            Instrument = payment.Instrument.ParseTo<PaymentInstrument>();
            Language = new Language(payment.Language);
            Number = payment.Number;
            Operation = payment.Operation;
            PayeeInfo = payment.PayeeInfo.Map();
            PayerReference = payment.PayerReference;
            InitiatingSystemUserAgent = payment.InitiatingSystemUserAgent;
            Prices = payment.Prices.Map();
            State = payment.State;
            Urls = new UrlsResponse(payment.Urls);
            UserAgent = payment.UserAgent;
            Metadata = new Metadata(payment.Metadata);
            RecurrenceToken = payment.RecurrenceToken;

            Authorizations = payment.Authorizations?.Map();
            Cancellations = payment.Cancellations?.Map();
            Captures = payment.Captures?.Map();
            Reversals = payment.Reversals?.Map();
            Transactions = payment.Transactions?.Map();
            Verifications = payment.Verifications?.Map();
            if (!string.IsNullOrEmpty(payment.Intent))
            {
                Intent = payment.Intent.ParseTo<PaymentIntent>();
            }
        }

        public Amount Amount { get; }

        public Amount RemainingCaptureAmount { get; }

        public Amount RemainingCancellationAmount { get; }

        public Amount RemainingReversalAmount { get; }

        public ICardPaymentAuthorizationListResponse Authorizations { get; }

        public ICancellationListResponse Cancellations { get; }

        public ICaptureListResponse Captures { get; }

        public DateTime Created { get; }

        public DateTime Updated { get; }

        public Currency Currency { get; }

        public string Description { get; }

        public Uri Id { get; }

        public PaymentInstrument Instrument { get; }

        public PaymentIntent Intent { get; }

        public Language Language { get; }

        public long Number { get; }

        public Operation Operation { get; }

        public IPayeeInfo PayeeInfo { get; }

        public string PayerReference { get; }

        public string InitiatingSystemUserAgent { get; }

        public IPriceListResponse Prices { get; }

        public IReversalListResponse Reversals { get; }

        public State State { get; }

        public ITransactionListResponse Transactions { get; }

        public IUrls Urls { get; }

        public string UserAgent { get; }

        public Metadata Metadata { get; }

        public string RecurrenceToken { get; }

        public Amount VatAmount { get; }
    }
}