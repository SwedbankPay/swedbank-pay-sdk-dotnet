namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public class SwishPaymentSaleRequest
    {
        public SwishPaymentSaleRequest(Msisdn msisdn)
        {
            Transaction = new SwishPaymentSaleTransaction(msisdn);
        }

        /// <summary>
        /// Transaction with prefill information about the consumer.
        /// </summary>
        public SwishPaymentSaleTransaction Transaction { get; }
    }
}
