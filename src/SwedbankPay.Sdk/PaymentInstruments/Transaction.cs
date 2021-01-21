using System;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    /// <summary>
    /// Low level information about a payment transaction.
    /// </summary>
    public class Transaction : Identifiable, ITransaction
    {
        /// <summary>
        /// Instantiates a new <see cref="Transaction"/> with the provided parameters.
        /// </summary>
        /// <param name="id">A unique reference to this transaction.</param>
        /// <param name="created">The <seealso cref="DateTime"/> the transaction was created.</param>
        /// <param name="updated">The <seealso cref="DateTime"/> the transaction was last updated.</param>
        /// <param name="type">The transaction type.</param>
        /// <param name="state">The last known state of this transaction.</param>
        /// <param name="number">Unique number of this transaction.</param>
        /// <param name="amount">Amount to charge the payer.</param>
        /// <param name="vatAmount">Amount to charge the payer as value added taxes.</param>
        /// <param name="description">A textual description of the payment.</param>
        /// <param name="payeeReference">Unique reference to this transaction in the merchant system.</param>
        /// <param name="isOperational">Indicates if this transaction was operational.</param>
        /// <param name="operations">Available operations for this transaction.</param>
        /// <param name="activity">Latest activity to happen to this transaction.</param>
        public Transaction(Uri id,
                           DateTime created,
                           DateTime updated,
                           TransactionType type,
                           State state,
                           long number,
                           Amount amount,
                           Amount vatAmount,
                           string description,
                           string payeeReference,
                           bool isOperational,
                           IOperationList operations,
                           string activity)
            : base(id)
        {
            Created = created;
            Updated = updated;
            Type = type;
            State = state;
            Number = number;
            Amount = amount;
            VatAmount = vatAmount;
            Description = description;
            PayeeReference = payeeReference;
            IsOperational = isOperational;
            Operations = operations;
            Activity = activity;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Amount Amount { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public DateTime Created { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public bool IsOperational { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public long Number { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IOperationList Operations { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string PayeeReference { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public State State { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public TransactionType Type { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public DateTime Updated { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Amount VatAmount { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string Activity { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IProblemResponse Problem { get; set; }
    }
}