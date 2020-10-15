namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public class SwishPaymentSaleRequest
    {
        public SwishPaymentSaleRequest(Msisdn msisdn)
        {
            Transaction = new SwishPaymentSaleTransaction(msisdn);
        }


        public SwishPaymentSaleTransaction Transaction;

        public class SwishPaymentSaleTransaction
        {
            protected internal SwishPaymentSaleTransaction(Msisdn msisdn)
            {
                Msisdn = msisdn;
            }


            public Msisdn Msisdn { get; }
        }
    }
}
