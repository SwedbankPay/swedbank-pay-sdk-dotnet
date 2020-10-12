
namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderResponse
    { 
        public PaymentOrderResponse(IOperationList operations, PaymentOrderResponseObject paymentorder)
        {
            Operations = operations;
            PaymentOrder = paymentorder;
        }

        public IOperationList Operations { get; }

        public PaymentOrderResponseObject PaymentOrder { get; }
    }
}