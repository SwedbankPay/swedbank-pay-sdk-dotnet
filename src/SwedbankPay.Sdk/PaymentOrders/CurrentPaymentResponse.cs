using System;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class CurrentPaymentResponse: ICurrentPaymentResponse
    {
        public CurrentPaymentResponse(Uri paymentOrder, string menuElementName, ICurrentPaymentResponseObject payment)
        {
            PaymentOrder = paymentOrder;
            MenuElementName = menuElementName;
            Payment = payment;
        }

        public Uri PaymentOrder { get; }
        public string  MenuElementName { get; }
        public ICurrentPaymentResponseObject Payment { get; }
    }
}