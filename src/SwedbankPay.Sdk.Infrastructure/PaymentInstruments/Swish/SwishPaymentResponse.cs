﻿using SwedbankPay.Sdk.Common;
using System;
using System.Globalization;
using System.Net.Http;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public class SwishPaymentResponse : ISwishPaymentResponse
    {
        public SwishPaymentResponse(SwishPaymentResponseDto payment,
                               HttpClient httpClient)
        {
            Payment = new SwishPayment(payment.Payment);
            Operations = new SwishPaymentOperations(payment.Operations.Map(), httpClient);
        }

        public ISwishPayment Payment { get; set; }
        public ISwishPaymentOperations Operations { get; set; }
    }

    public class SwishPaymentResponseObject
    {
        public SwishPaymentResponseObject(Uri id,
                               string number,
                               DateTime created,
                               DateTime updated,
                               PaymentInstrument instrument,
                               Operation operation,
                               PaymentIntent intent,
                               State state,
                               CurrencyCode currency,
                               IPricesListResponse prices,
                               Amount amount,
                               Amount remainingReversalAmount,
                               string description,
                               string payerReference,
                               string initiatingSystemUserAgent,
                               string userAgent,
                               CultureInfo language,
                               ITransactionListResponse transactions,
                               ISwishSaleListResponse sales,
                               IReversalsListResponse reversals,
                               IUrls urls,
                               PayeeInfo payeeInfo,
                               MetadataResponse metadata)
        {
            Id = id;
            Number = number;
            Created = created;
            Updated = updated;
            Instrument = instrument;
            Operation = operation;
            Intent = intent;
            State = state;
            Currency = currency;
            Prices = prices;
            Amount = amount;
            RemainingReversalAmount = remainingReversalAmount;
            Description = description;
            PayerReference = payerReference;
            InitiatingSystemUserAgent = initiatingSystemUserAgent;
            UserAgent = userAgent;
            Language = language;
            Transactions = transactions;
            Sales = sales;
            Reversals = reversals;
            Urls = urls;
            PayeeInfo = payeeInfo;
            Metadata = metadata;
        }


        public string Number { get; }
        public DateTime Created { get; }
        public DateTime Updated { get; }
        public PaymentInstrument Instrument { get; }
        public Operation Operation { get; }
        public PaymentIntent Intent { get; }
        public State State { get; }
        public CurrencyCode Currency { get; }
        public IPricesListResponse Prices { get; }
        public Amount Amount { get; }
        public Amount RemainingReversalAmount { get; set; }
        public string Description { get; }
        public string PayerReference { get; }
        public string InitiatingSystemUserAgent { get; }
        public string UserAgent { get; }
        public CultureInfo Language { get; }
        public ITransactionListResponse Transactions { get; }
        public ISwishSaleListResponse Sales { get; }
        public IReversalsListResponse Reversals { get; }
        public IUrls Urls { get; }
        public PayeeInfo PayeeInfo { get; }
        public Uri Id { get; }
        public MetadataResponse Metadata { get; }
    }
}