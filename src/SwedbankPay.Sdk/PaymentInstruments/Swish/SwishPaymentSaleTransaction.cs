namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public class SwishPaymentSaleTransaction
    {
        public SwishPaymentSaleTransaction(Msisdn msisdn)
        {
            Msisdn = msisdn;
        }

        /// <summary>
        /// Prefill information about the payer.
        /// </summary>
        public Msisdn Msisdn { get; }
    }
}
