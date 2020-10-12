using SwedbankPay.Sdk.PaymentOrders;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public interface ICardPaymentCaptureRequest
    {
        Amount Amount { get; }
        string Description { get; }
        List<OrderItem> OrderItems { get; }
        string PayeeReference { get; }
        Amount VatAmount { get; }
    }
}