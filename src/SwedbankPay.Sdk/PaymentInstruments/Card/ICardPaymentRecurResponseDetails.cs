using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public interface ICardPaymentRecurResponseDetails
    {
        Uri Id { get; }

        string RecurrenceToken { get; }

        long Number { get; }

        DateTime Created { get; }

        DateTime Updated { get; }

        PaymentInstrument Instrument { get; }

        Operation Operation { get; }

        State State { get; }

        Currency Currency { get; }

        IPricesListResponse Prices { get; }

        Amount Amount { get; }

        Amount ReminaingCaptureAmount { get; }

        Amount RemainingCancellationAmount { get; }

        string Description { get; }

        string InitiatingSystemUserAgent { get; }

        string UserAgent { get; }

        ITransactionListResponse Transactions { get; }

        ICardPaymentAuthorization Authorizations { get; }

        IUrls Urls { get; }

        PayeeInfo PayeeInfo { get; }

        MetadataResponse MetaData { get; }
    }
}