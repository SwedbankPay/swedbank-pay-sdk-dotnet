namespace SwedbankPay.Sdk.PaymentOrders
{
    internal class PaymentOrderUpdateRequestDetailsDto
    {
        public PaymentOrderUpdateRequestDetailsDto(PaymentOrderUpdateRequestDetails paymentOrder)
        {
            Amount = paymentOrder.Amount.InLowestMonetaryUnit;
            Operation = paymentOrder.Operation.Value;
            VatAmount = paymentOrder.VatAmount?.InLowestMonetaryUnit;
        }

        public long Amount { get; }

        public string Operation { get; }

        public long? VatAmount { get; }
    }
}