using SwedbankPay.Sdk.PaymentInstruments.Swish;
using System;
using SwedbankPay.Sdk.PaymentInstruments;
using SwedbankPay.Sdk.Common;
using SwedbankPay.Sdk.PaymentInstruments.Card;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class CurrentPaymentResponseObject : IdLink, ICurrentPaymentResponseObject
    {
        public CurrentPaymentResponseObject(PaymentOrderPaymentDto payment)
        {
            Number = payment.Number;
            Instrument = Enum.Parse<PaymentInstrument>(payment.Instrument);
            Created = payment.Created;
            Updated = payment.Updated;
            Amount = payment.Amount;
            Authorizations = payment.Authorizations.Map();
            Cancellations = payment.Cancellations.Map();
            Captures = payment.Captures.Map();
            Currency = new CurrencyCode(payment.Currency);
            Description = payment.Description;
            Intent = Enum.Parse<PaymentIntent>(payment.Intent);
            Language = new Language(payment.Language);
            Operation = payment.Operation;
            PayeeInfo = payment.PayeeInfo.Map();
            PayerReference = payment.PayerReference;
            PaymentToken = payment.PaymentToken;
            Prices = payment.Prices.Map();
            Reversals = payment.Reversals.Map();
            State = payment.State;
            Transactions = payment.Transactions.Map();
            Urls = new IdLink { Id = new Uri(payment.Urls.Id, UriKind.RelativeOrAbsolute)};
            UserAgent = payment.UserAgent;
            Sales = payment.Sales.Map();
        }

        public CurrentPaymentResponseObject(string number,
                                            PaymentInstrument instrument,
                                            DateTime created,
                                            DateTime updated,
                                            Amount amount,
                                            IPaymentAuthorizationListResponse authorizations,
                                            ICancellationsListResponse cancellations,
                                            ICapturesListResponse captures,
                                            CurrencyCode currency,
                                            string description,
                                            PaymentIntent intent,
                                            Language language,
                                            Operation operation,
                                            PayeeInfo payeeInfo,
                                            string payerReference,
                                            string paymentToken,
                                            IPricesListResponse prices,
                                            IReversalsListResponse reversals,
                                            State state,
                                            ITransactionListResponse transactions,
                                            IdLink urls,
                                            string userAgent,
                                            ISaleListResponse sales)
        {
            Number = number;
            Instrument = instrument;
            Created = created;
            Updated = updated;
            Amount = amount;
            Authorizations = authorizations;
            Cancellations = cancellations;
            Captures = captures;
            Currency = currency;
            Description = description;
            Intent = intent;
            Language = language;
            Operation = operation;
            PayeeInfo = payeeInfo;
            PayerReference = payerReference;
            PaymentToken = paymentToken;
            Prices = prices;
            Reversals = reversals;
            State = state;
            Transactions = transactions;
            Urls = urls;
            UserAgent = userAgent;
            Sales = sales;
        }


        public string Number { get; }
        public PaymentInstrument Instrument { get; }
        public DateTime Created { get; }
        public DateTime Updated { get; }
        public Amount Amount { get; }
        public IPaymentAuthorizationListResponse Authorizations { get; }
        public ICancellationsListResponse Cancellations { get; }
        public ICapturesListResponse Captures { get; }
        public CurrencyCode Currency { get; }
        public string Description { get; }
        public PaymentIntent Intent { get; }
        public Language Language { get; }
        public Operation Operation { get; }
        public PayeeInfo PayeeInfo { get; }
        public string PayerReference { get; }
        public string PaymentToken { get; }
        public IPricesListResponse Prices { get; }
        public IReversalsListResponse Reversals { get; }
        public State State { get; }
        public ITransactionListResponse Transactions { get; }
        public IdLink Urls { get; }
        public string UserAgent { get; }
        public ISaleListResponse Sales { get; }
    }
}