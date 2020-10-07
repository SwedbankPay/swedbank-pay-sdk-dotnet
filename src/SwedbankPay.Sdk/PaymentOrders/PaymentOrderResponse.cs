
namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderResponse
    { 
        public PaymentOrderResponse(OperationList operations, PaymentOrderResponseObject paymentorder)
        {
            Operations = operations;
            PaymentOrder = paymentorder;
        }

        public OperationList Operations { get; }

        public PaymentOrderResponseObject PaymentOrder { get; }
    }
}