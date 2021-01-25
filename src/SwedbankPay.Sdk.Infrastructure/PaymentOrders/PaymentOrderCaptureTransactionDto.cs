using System.Collections.Generic;
using System.Linq;

namespace SwedbankPay.Sdk.PaymentOrders
{
    internal class PaymentOrderCaptureTransactionDto
    {
        public PaymentOrderCaptureTransactionDto(PaymentOrderCaptureTransaction transaction)
        {
            Amount = transaction.Amount.InLowestMonetaryUnit;
            Description = transaction.Description;
            if( transaction.OrderItems != null && transaction.OrderItems.Any())
            {
                OrderItems = new List<OrderItemDto>();
                foreach (var item in transaction.OrderItems)
                {
                    OrderItems.Add(new OrderItemDto(item));
                }
            }
            PayeeReference = transaction.PayeeReference;
            VatAmount = transaction.VatAmount?.InLowestMonetaryUnit;
        }

        public long Amount { get; }

        public string Description { get; }

        public List<OrderItemDto> OrderItems { get; }

        public string PayeeReference { get; }

        public long? VatAmount { get; }
    }
}