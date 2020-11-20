namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderUpdateRequestDetails
    {
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