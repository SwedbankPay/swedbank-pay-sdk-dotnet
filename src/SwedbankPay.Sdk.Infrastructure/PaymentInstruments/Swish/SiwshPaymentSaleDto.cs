using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public class SiwshPaymentSaleDto
    {
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public Uri Id { get; set; }
        public string PaymentRequestToken { get; set; }
        public TransactionDto Transaction { get; set; }

        internal SwishPaymentSale Map()
        {
            return new SwishPaymentSale(Id, Created, Updated, PaymentRequestToken, Transaction.Map());
        }
    }
}