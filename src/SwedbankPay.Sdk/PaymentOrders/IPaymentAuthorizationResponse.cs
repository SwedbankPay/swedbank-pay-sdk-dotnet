using SwedbankPay.Sdk.PaymentInstruments;
using System;

namespace SwedbankPay.Sdk.PaymentOrders
{
    /// <summary>
    /// Transactional details for a authorization in payment order.
    /// </summary>
    public interface IPaymentAuthorizationResponse : IIdentifiable
    {
        /// <summary>
        /// The <seealso cref="DateTime"/> this authorization was created.
        /// </summary>
        public DateTime Created { get; }

        /// <summary>
        /// The <seealso cref="DateTime"/> this authorization was last updated.
        /// </summary>
        public DateTime Updated { get; }

        /// <summary>
        /// Indicates the transaction type.
        /// </summary>
        public PaymentType Type { get; }

        /// <summary>
        /// Indicates the state of the transaction
        /// If a partial has been done and further transactionsare possible, the state will be <seealso cref="State.AwaitingActivity"/>.
        /// </summary>
        public State State { get; }

        /// <summary>
        /// The transaction number, useful when there’s need to reference the transaction in human communication.
        /// Not usable for programmatic identification of the transaction, where <see cref="IIdentifiable.Id"/> should be used instead.
        /// </summary>
        public long Number { get; }

        /// <summary>
        /// The amount (including VAT, if any) to charge the payer, entered in the lowest monetary unit of the selected currency.
        /// </summary>
        public Amount Amount { get; }

        /// <summary>
        /// The payment’s VAT (Value Added Tax) amount, entered in the lowest monetary unit of the selected currency.
        /// The vatAmount entered will not affect the amount shown on the payment page, which only shows the total amount.
        /// This field is used to specify how much ofthe total amount the VAT will be.
        /// Set to 0 (zero) if there is no VAT amount charged.
        /// </summary>
        public Amount VatAmount { get; }

        /// <summary>
        /// A 40 character length textual description of the purchase.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// A unique reference from the merchant system.
        /// It is set per operation to ensure an exactly-once delivery of a transactional operation.
        /// See payeeReference for details.
        /// In Invoice Payments payeeReference is used as an invoice/receipt number, if the receiptReference is not defined.
        /// </summary>
        public string PayeeReference { get; }
    }
}