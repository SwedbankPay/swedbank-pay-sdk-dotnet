namespace SwedbankPay.Sdk.PaymentOrders
{
    /// <summary>
    /// API details for updating the amounts on a payment order.
    /// </summary>
    public class PaymentOrderUpdateRequestDetails
    {
        /// <summary>
        /// Instantiates a <see cref="PaymentOrderUpdateRequestDetails"/> with the provided parameters.
        /// </summary>
        /// <param name="amount">The amount to update to.</param>
        /// <param name="vatAmount">The VAT amount to update to.</param>
        protected internal PaymentOrderUpdateRequestDetails(Amount amount, Amount vatAmount)
        {
            Operation = Operation.UpdateOrder;
            Amount = amount;
            VatAmount = vatAmount;
        }


        /// <summary>
        ///     The amount including VAT in the lowest monetary unit of the currency. E.g. 10000 equals 100.00 NOK and 5000 equals
        ///     50.00 NOK.
        /// </summary>
        public Amount Amount { get; }

        /// <summary>
        ///     The operation that the payment order is supposed to perform.
        ///     Set to <seealso cref="Operation.UpdateOrder"/>
        /// </summary>

        public Operation Operation { get; }

        /// <summary>
        ///     The amount of VAT in the lowest monetary unit of the currency. E.g. 10000 equals 100.00 NOK and 5000 equals 50.00
        ///     NOK.
        /// </summary>
        public Amount VatAmount { get; }
    }
}