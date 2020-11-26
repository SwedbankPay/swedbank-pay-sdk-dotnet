using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class CardPaymentRecurResponseDetails : ICardPaymentRecurResponseDetails
    {
        public CardPaymentRecurResponseDetails(CardPaymentRecurResponseDetailsDto dto)
        {
            Id = dto.Id;
            RecurrenceToken = dto.RecurrenceToken;
            Number = dto.Number;
            Created = dto.Created;
            Updated = dto.Updated;
            Instrument = Enum.Parse<PaymentInstrument>(dto.Instrument);
            Operation = dto.Operation;
            Intent = Enum.Parse<PaymentIntent>(dto.Intent);
            State = dto.State;
            Currency = new Currency(dto.Currency);
            Prices = dto.Prices.Map();
            Amount = dto.Amount;
            VatAmount = dto.VatAmount;
            RemainingCancellationAmount = dto.RemainingCancellationAmount;
            ReminaingCaptureAmount = dto.ReminaingCaptureAmount;
            Description = dto.Description;
            InitiatingSystemUserAgent = dto.InitiatingSystemUserAgent;
            UserAgent = dto.UserAgent;
            Transactions = dto.Transactions.Map();
            Authorizations = dto.Authorizations.MapToCard();
            Urls = dto.Urls.Map();
            PayeeInfo = dto.PayeeInfo.Map();
            MetaData = dto.MetaData;
        }

        public Uri Id { get; }

        public string RecurrenceToken { get; }

        public long Number { get; }

        public DateTime Created { get; }

        public DateTime Updated { get; }

        public PaymentInstrument Instrument { get; }

        public Operation Operation { get; }

        public PaymentIntent Intent { get; }

        public State State { get; }

        public Currency Currency { get; }

        public IPricesListResponse Prices { get; }

        public Amount Amount { get; }

        public Amount VatAmount { get; }

        public Amount ReminaingCaptureAmount { get; }

        public Amount RemainingCancellationAmount { get; }

        public string Description { get; }

        public string InitiatingSystemUserAgent { get; }

        public string UserAgent { get; }

        public ITransactionListResponse Transactions { get; }

        public ICardPaymentAuthorization Authorizations { get; }

        public IUrls Urls { get; }

        public PayeeInfo PayeeInfo { get; }

        public MetadataResponse MetaData { get; }
    }
}