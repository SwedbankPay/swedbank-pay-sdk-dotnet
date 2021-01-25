using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    internal class SiwshPaymentSaleDto
    {
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Id { get; set; }
        public string PaymentRequestToken { get; set; }
        public TransactionDto Transaction { get; set; }

        internal SwishPaymentSale Map()
        {
            var uri = new Uri(Id, UriKind.RelativeOrAbsolute);
            return new SwishPaymentSale(uri, Created, Updated, PaymentRequestToken, Transaction.Map());
        }
    }
}