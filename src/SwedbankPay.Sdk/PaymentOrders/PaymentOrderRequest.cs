using System;

namespace SwedbankPay.Sdk.PaymentOrders
{
    using System.Collections.Generic;

    using SwedbankPay.Sdk.Payments;

    public class PaymentOrderRequest
    {
        public PaymentOrderRequest(Operation operation,
                                   CurrencyCode currency,
                                   Amount amount,
                                   Amount vatAmount,
                                   string description,
                                   string userAgent,
                                   Language language,
                                   bool generateRecurrenceToken,
                                   Urls urls,
                                   PayeeInfo payeeInfo,
                                   Payer payer = null,
                                   List<OrderItem> orderItems = null,
                                   RiskIndicator riskIndicator = null,
                                   Dictionary<string, object> metaData = null,
                                   List<Item> items = null)
        {
            Operation = operation ?? throw new ArgumentNullException(nameof(operation));
            Currency = currency ?? throw new ArgumentNullException(nameof(currency));
            Amount = amount ?? throw new ArgumentNullException(nameof(amount));
            VatAmount = vatAmount ?? throw new ArgumentNullException(nameof(vatAmount));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            UserAgent = userAgent ?? throw new ArgumentNullException(nameof(userAgent)); 
            Language = language ?? throw new ArgumentNullException(nameof(language)); 
            GenerateRecurrenceToken = generateRecurrenceToken;
            Urls = urls ?? new Urls();
            PayeeInfo = payeeInfo;
            Payer = payer;
            OrderItems = orderItems;
            RiskIndicator = riskIndicator;
            MetaData = metaData;
            Items = items;  
        }
        /// <summary>
        /// The operation that the payment order is supposed to perform.
        /// </summary>
        
        public Operation Operation { get; }

        /// <summary>
        /// The currency of the payment.
        /// </summary>
        public CurrencyCode Currency { get; }

        /// <summary>
        /// The amount including VAT in the lowest monetary unit of the currency. E.g. 10000 equals 100.00 NOK and 5000 equals 50.00 NOK.
        /// </summary>
        public Amount Amount { get; }

        /// <summary>
        /// The amount of VAT in the lowest monetary unit of the currency. E.g. 10000 equals 100.00 NOK and 5000 equals 50.00 NOK.
        /// </summary>
        public Amount VatAmount { get; }

        /// <summary>
        /// The description of the payment order.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// The user agent of the payer.
        /// </summary>
        public string UserAgent { get; }

        /// <summary>
        /// The language of the payer.
        /// </summary>
        public Language Language { get; }

        /// <summary>
        /// Determines if a recurrence token should be generated. A recurrence token is primarily used to enable future recurring payments - with the same token - through server-to-server calls. Default value is false
        /// </summary>
        public bool GenerateRecurrenceToken { get; }

        /// <summary>
        /// The urls property of the paymentOrder contains the URIs related to a payment order, including where the consumer gets redirected when going forward
        /// with or cancelling a payment session, as well as the callback URI that is used to inform the payee (merchant) of changes or updates made to underlying payments or transaction.
        /// </summary>
        public Urls Urls { get; }

        /// <summary>
        /// Information about the payee of the payment order
        /// </summary>
        public PayeeInfo PayeeInfo { get; }

        /// <summary>
        /// Information about the payee of the payment order
        /// </summary>
        public Payer Payer { get; }

        /// <summary>
        /// The array of items being purchased with the order. Used to print on invoices if the payer chooses to pay with invoice, among other things.
        /// </summary>
        public List<OrderItem> OrderItems { get; }

        //Information about risk indicator
        public RiskIndicator RiskIndicator { get; }

        /// <summary>
        /// The keys and values that should be associated with the payment order. Can be additional identifiers and data you want to associate with the payment.
        /// </summary>
        public Dictionary<string, object> MetaData { get; }

        /// <summary>
        /// The array of items that will affect how the payment is performed.
        /// </summary>
        public List<Item> Items { get; }
    }
}
