using SwedbankPay.Sdk.PaymentOrders;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class CardPaymentCaptureTransactionDto
    {
        public CardPaymentCaptureTransactionDto(CardPaymentCaptureTransaction transaction)
        {
            Amount = transaction.Amount.InLowestMonetaryUnit;
            Description = transaction.Description;
            PayeeReference = transaction.PayeeReference;
            VatAmount = transaction.VatAmount.InLowestMonetaryUnit;

            if (transaction.OrderItems != null)
            {
                OrderItems = new List<OrderItemDto>();
                foreach (var item in transaction.OrderItems)
                {
                    OrderItems.Add(new OrderItemDto(item));
                }
            }
        }

        public long Amount { get; }

        public string Description { get; }

        public List<OrderItemDto> OrderItems { get; }

        public string PayeeReference { get; }

        public long VatAmount { get; }
    }
}