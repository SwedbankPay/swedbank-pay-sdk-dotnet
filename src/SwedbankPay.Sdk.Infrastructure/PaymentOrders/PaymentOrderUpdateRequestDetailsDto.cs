using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
	internal class PaymentOrderUpdateRequestDetailsDto
	{
		public PaymentOrderUpdateRequestDetailsDto(PaymentOrderUpdateRequestDetails paymentOrder)
		{
			Amount = paymentOrder.Amount.InLowestMonetaryUnit;
			Operation = paymentOrder.Operation.Value;
			VatAmount = paymentOrder.VatAmount?.InLowestMonetaryUnit;
            foreach (var item in paymentOrder.OrderItems)
            {
				OrderItems.Add(new OrderItemDto(item));
            }
		}

		public long Amount { get; }

		public string Operation { get; }

		public long? VatAmount { get; }

		public IList<OrderItemDto> OrderItems { get; } = new List<OrderItemDto>();
	}
}