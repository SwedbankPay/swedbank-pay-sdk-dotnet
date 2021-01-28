using System;

namespace SwedbankPay.Sdk.PaymentOrders
{
    /// <summary>
    /// Detailed information about a payment order.
    /// </summary>
    public interface IPaymentOrder : IIdentifiable
    {
        /// <summary>
        /// The amount (including VAT, if any) to charge the payer,
        /// entered in the lowest monetary unit of the selected currency.
        /// </summary>
        public Amount Amount { get; }

        /// <summary>
        /// The <seealso cref="DateTime"/> the payment order was created.
        /// </summary>
        public DateTime Created { get; }

        /// <summary>
        /// The selected currency for this payment order.
        /// </summary>
        public Currency Currency { get; }

        /// <summary>
        /// Resource where information about the current – and sole active – payment can be retrieved.
        /// </summary>
        public ICurrentPaymentResponse CurrentPayment { get; }

        /// <summary>
        /// A 40 character length textual description of the purchase.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Payers prefered language.
        /// </summary>
        public Language Language { get; }

        /// <summary>
        /// Metadata can be used to store data associated to a payment order that can be retrieved later by performing a GET on the payment order.
        /// Swedbank Pay does not use or process metadata,
        /// it is only stored on the payment order so it can be retrieved later alongside the payment order.
        /// An example where metadata might be useful is when several internal systems are involved in the payment process and the payment creation is done in one system and post-purchases take place in another.
        /// In order to transmit data between these two internal systems,
        /// the data can be stored in metadata on the payment order so the internal systems do not need to communicate with each other directly.
        /// </summary>
        public Metadata Metadata { get; }

        /// <summary>
        /// The <see cref="Operation"/> used to initate this payment order.
        /// </summary>
        public string Operation { get; }

        /// <summary>
        /// Resource that gives access to the <seealso cref="IOrderItem"/>s this payment order contains.
        /// </summary>
        public OrderItemListResponse OrderItems { get; }

        /// <summary>
        /// Identifies the merchant that initiated the payment.
        /// </summary>
        public IPayeeInfo PayeeInfo { get; }

        /// <summary>
        /// Resource where information about the payee of the payment order can be retrieved.
        /// </summary>
        public PayerResponse Payers { get; }

        /// <summary>
        /// Resource where information about all underlying payments can be retrieved.
        /// </summary>
        public Identifiable Payments { get; }

        /// <summary>
        /// The available <seealso cref="Sdk.Amount"/> to cancel.
        /// </summary>
        public Amount RemainingCancelAmount { get; }

        /// <summary>
        /// The available <seealso cref="Sdk.Amount"/> to capture.
        /// </summary>
        public Amount RemainingCaptureAmount { get; }

        /// <summary>
        /// The available <seealso cref="Sdk.Amount"/> to reverse.
        /// </summary>
        public Amount RemainingReversalAmount { get; }

        /// <summary>
        /// For admin users gives detailed information about current settings.
        /// </summary>
        public Identifiable Settings { get; }

        /// <summary>
        /// Indicates the state of the payment order.
        /// Does not reflect the state of any ongoing payments initiated from the payment order.
        /// This field is only for status display purposes.
        /// </summary>
        public State State { get; }

        /// <summary>
        /// The <seealso cref="DateTime"/> this payment order was last updated.
        /// </summary>
        public DateTime Updated { get; }

        /// <summary>
        /// Resource where all URIs related to the payment order can be retrieved.
        /// </summary>
        public IUrls Urls { get; }

        /// <summary>
        /// The user agent string of the payer’s browser.
        /// </summary>
        public string UserAgent { get; }

        /// <summary>
        /// The payment’s VAT (Value Added Tax) amount, entered in the lowest monetary unit of the selected currency.
        /// The vatAmount entered will not affect the amount shown on the payment page, which only shows the total amount.
        /// This field is used to specify how much ofthe total amount the VAT will be.
        /// Set to 0 (zero) if there is no VAT amount charged.
        /// </summary>
        public Amount VatAmount { get; }
    }
}