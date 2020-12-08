namespace SwedbankPay.Sdk.PaymentOrders
{
    internal class PaymentOrderUpdateRequestDetailsDto
    {
        public PaymentOrderUpdateRequestDetailsDto(PaymentOrderUpdateRequestDetails paymentOrder)
        {
            Amount = paymentOrder.Amount;
            Operation = paymentOrder.Operation.Value;
            VatAmount = paymentOrder.VatAmount;
        }

        public long Amount { get; }

        public string Operation { get; }

        public long? VatAmount { get; }
    }
}