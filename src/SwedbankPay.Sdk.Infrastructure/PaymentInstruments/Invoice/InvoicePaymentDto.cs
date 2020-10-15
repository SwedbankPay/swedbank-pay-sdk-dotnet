using System;
using System.Collections.Generic;
using System.Globalization;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public class InvoicePaymentDto
    {
        public int Amount;
        public int RemainingCaptureAmount;
        public int RemainingCancellationAmount;
        public int RemainingReversalAmount;
        public InvoicePaymentAuthorizationListDto Authorizations;
        public ICancellationsListResponse Cancellations;
        public ICapturesListResponse Captures;
        public DateTime Created;
        public DateTime Updated;
        public CurrencyCode Currency;
        public string Description;
        public Uri Id;
        public string Instrument;
        public string Intent;
        public CultureInfo Language;
        public string Number;
        public Operation Operation;
        public PayeeInfoDto PayeeInfo;
        public string PayerReference;
        public string InitiatingSystemUserAgent;
        public PricesDto Prices;
        public ReversalsListResponseDto Reversals;
        public string State;
        public ITransactionListResponse Transactions;
        public UrlsDto Urls;
        public string UserAgent;
        public Dictionary<string, object> Metadata;
    }
}