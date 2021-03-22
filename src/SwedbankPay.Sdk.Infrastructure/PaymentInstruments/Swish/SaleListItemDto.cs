using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
	internal class SaleListItemDto
	{
		public SaleListItemDto(DateTime date, Uri id, string payerAlias, string paymentRequestToken, string swishPaymentReference, string swishStatus, TransactionDto transaction)
		{
			Date = date;
			Id = id;
			PayerAlias = payerAlias;
			PaymentRequestToken = paymentRequestToken;
			SwishPaymentReference = swishPaymentReference;
			SwishStatus = swishStatus;
			Transaction = transaction;
		}

		public DateTime Date { get; }
		public Uri Id { get; }
		public string PayerAlias { get; }
		public string PaymentRequestToken { get; }
		public string SwishPaymentReference { get; }
		public string SwishStatus { get; }
		public TransactionDto Transaction { get; }
	}
}