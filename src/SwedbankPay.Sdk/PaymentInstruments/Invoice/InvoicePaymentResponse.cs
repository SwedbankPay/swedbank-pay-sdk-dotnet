using System;
using System.Globalization;

using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk.Payments.InvoicePayments
{
    public class InvoicePaymentResponse : IInvoicePayment
    {
        public InvoicePaymentResponse(PaymentResponseObject payment,
                               IOperationList operations)
        {
            this.Payment = payment;
            this.Operations = operations;
        }
        public Amount Amount { get; }
        public Amount RemainingCaptureAmount { get; }
        public Amount RemainingCancellationAmount { get; }
        public Amount RemainingReversalAmount { get; }
        public InvoicePaymentAuthorizationListResponse Authorizations { get; }
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

        public PaymentResponseObject PaymentResponse => throw new NotImplementedException();

        IInvoicePaymentOperations Operations => throw new NotImplementedException();
    }
}