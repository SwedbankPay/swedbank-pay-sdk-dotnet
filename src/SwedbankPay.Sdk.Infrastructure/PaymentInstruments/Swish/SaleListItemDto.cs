using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish;

	internal class SaleListItemDto
	{
		public DateTime Date { get; set; }
		public Uri Id { get; set; }
		public string PayerAlias { get; set; }
		public string PaymentRequestToken { get; set; }
		public string SwishPaymentReference { get; set; }
		public string SwishStatus { get; set; }
		public TransactionDto Transaction { get; set; }
	}