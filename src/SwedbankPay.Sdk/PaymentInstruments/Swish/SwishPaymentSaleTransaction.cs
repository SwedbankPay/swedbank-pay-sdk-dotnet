namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public class SwishPaymentSaleTransaction
    {
        protected internal SwishPaymentSaleTransaction(Msisdn msisdn)
        {
            Msisdn = msisdn;
        }


        public Msisdn Msisdn { get; }
    }
}
