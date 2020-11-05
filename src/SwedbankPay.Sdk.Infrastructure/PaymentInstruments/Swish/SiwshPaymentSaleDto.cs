using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public class SiwshPaymentSaleDto
    {
        public DateTime Date { get; set; }
        public Uri Id { get; set; }
        public string PaymentRequestToken { get; set; }
        public TransactionDto Transaction { get; set; }

        internal SiwshPaymentSale Map()
        {
            return new SiwshPaymentSale(Date, PaymentRequestToken, Id, Transaction.Map());
        }
    }
}