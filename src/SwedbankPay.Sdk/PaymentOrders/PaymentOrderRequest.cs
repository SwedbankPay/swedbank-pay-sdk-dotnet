namespace SwedbankPay.Sdk.PaymentOrders
{
    using System.Collections.Generic;

    public class PaymentOrderRequest
    {
        /// <summary>
        /// The operation that the payment order is supposed to perform.
        /// </summary>
        public string Operation { get; internal set; }

        /// <summary>
        /// The currency of the payment.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// The amount including VAT in the lowest monetary unit of the currency. E.g. 10000 equals 100.00 NOK and 5000 equals 50.00 NOK.
        /// </summary>
        public long? Amount { get; set; }

        /// <summary>
        /// The amount of VAT in the lowest monetary unit of the currency. E.g. 10000 equals 100.00 NOK and 5000 equals 50.00 NOK.
        /// </summary>
        public long? VatAmount { get; set; }

        /// <summary>
        /// The description of the payment order.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The user agent of the payer.
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// The language of the payer.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Determines if a recurrence token should be generated. A recurrence token is primarily used to enable future recurring payments - with the same token - through server-to-server calls. Default value is false
        /// </summary>
        public bool GenerateRecurrenceToken { get; set; }
        /// <summary>
        /// The urls property of the paymentOrder contains the URIs related to a payment order, including where the consumer gets redirected when going forward
        /// with or cancelling a payment session, as well as the callback URI that is used to inform the payee (merchant) of changes or updates made to underlying payments or transaction.
        /// </summary>
        public Urls Urls { get; set; }

        public PayeeInfo PayeeInfo { get; set; } //TODO Write doc

        public Payer Payer { get; set; } //TODO Write doc

        /// <summary>
        /// The array of items being purchased with the order. Used to print on invoices if the payer chooses to pay with invoice, among other things.
        /// </summary>
        public List<OrderItem> OrderItems { get; set; }

        public RiskIndicator RiskIndicator { get; set; } //TODO Write doc
        /// <summary>
        /// The keys and values that should be associated with the payment order. Can be additional identifiers and data you want to associate with the payment.
        /// </summary>
        public Dictionary<string, object> MetaData { get; set; }

        /// <summary>
        /// The array of items that will affect how the payment is performed.
        /// </summary>
        public List<Item> Items { get; set; }
    }
}
