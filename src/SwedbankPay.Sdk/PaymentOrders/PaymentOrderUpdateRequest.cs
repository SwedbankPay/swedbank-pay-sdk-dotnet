namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderUpdateRequest
    {
        public PaymentOrderUpdateRequest()
        {
            Operation = Operation.UpdateOrder;
        }


        /// <summary>
        ///     The amount including VAT in the lowest monetary unit of the currency. E.g. 10000 equals 100.00 NOK and 5000 equals
        ///     50.00 NOK.
        /// </summary>
        public Amount Amount { get; set; }

        /// <summary>
        ///     The operation that the payment order is supposed to perform.
        /// </summary>

        public Operation Operation { get; }

        /// <summary>
        ///     The amount of VAT in the lowest monetary unit of the currency. E.g. 10000 equals 100.00 NOK and 5000 equals 50.00
        ///     NOK.
        /// </summary>
        public Amount VatAmount { get; set; }
    }
}