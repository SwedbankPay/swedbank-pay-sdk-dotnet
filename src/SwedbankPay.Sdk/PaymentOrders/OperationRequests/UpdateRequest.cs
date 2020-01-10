namespace SwedbankPay.Sdk.PaymentOrders.OperationRequests
{
    public class UpdateRequest
    {
        public UpdateRequest(Amount amount, Amount vatAmount)
        {
            PaymentOrder = new PaymentOrderUpdateRequestObject(amount, vatAmount);
        }
        
        public PaymentOrderUpdateRequestObject PaymentOrder { get; }


        public class PaymentOrderUpdateRequestObject
        {
            protected internal PaymentOrderUpdateRequestObject(Amount amount, Amount vatAmount)
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
            /// </summary>

            public Operation Operation { get; }

            /// <summary>
            ///     The amount of VAT in the lowest monetary unit of the currency. E.g. 10000 equals 100.00 NOK and 5000 equals 50.00
            ///     NOK.
            /// </summary>
            public Amount VatAmount { get; }
        }
    }
}