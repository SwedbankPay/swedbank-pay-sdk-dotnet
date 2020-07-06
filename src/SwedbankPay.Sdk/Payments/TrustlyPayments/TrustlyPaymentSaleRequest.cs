namespace SwedbankPay.Sdk.Payments.TrustlyPayments
{
    public class TrustlyPaymentSaleRequest
    {
        public TrustlyPaymentSaleRequest(Msisdn msisdn)
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
