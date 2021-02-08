using SwedbankPay.Sdk.Extensions;
using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class CardPaymentRecurResponseDetails : ICardPaymentRecurResponseDetails
    {
        public CardPaymentRecurResponseDetails(CardPaymentRecurResponseDetailsDto dto)
        {
            Id = new Uri(dto.Id, UriKind.RelativeOrAbsolute);
            RecurrenceToken = dto.RecurrenceToken;
            Number = dto.Number;
            Created = dto.Created;
            Updated = dto.Updated;
            Instrument = StringExtensions.Parse<PaymentInstrument>(dto.Instrument);
            Operation = dto.Operation;
            State = dto.State;
            Currency = new Currency(dto.Currency);
            Amount = dto.Amount;
            RemainingCancellationAmount = dto.RemainingCancellationAmount;
            RemainingCaptureAmount = dto.ReminaingCaptureAmount;
            Description = dto.Description;
            InitiatingSystemUserAgent = dto.InitiatingSystemUserAgent;
            UserAgent = dto.UserAgent;
            MetaData = dto.MetaData?.Map();
            Authorizations = dto.Authorizations?.MapToCard();
            Transactions = dto.Transactions?.Map();
            Urls = dto.Urls?.Map();
            PayeeInfo = dto.PayeeInfo?.Map();
            Prices = dto.Prices?.Map();
        }

        public Uri Id { get; }

        public string RecurrenceToken { get; }

        public long Number { get; }

        public DateTime Created { get; }

        public DateTime Updated { get; }

        public PaymentInstrument Instrument { get; }

        public Operation Operation { get; }

        public State State { get; }

        public Currency Currency { get; }

        public IPriceListResponse Prices { get; }

        public Amount Amount { get; }

        public Amount RemainingCaptureAmount { get; }

        public Amount RemainingCancellationAmount { get; }

        public string Description { get; }

        public string InitiatingSystemUserAgent { get; }

        public string UserAgent { get; }

        public ITransactionListResponse Transactions { get; }

        public ICardPaymentAuthorization Authorizations { get; }

        public IUrls Urls { get; }

        public IPayeeInfo PayeeInfo { get; }

        public Metadata MetaData { get; }
    }
}