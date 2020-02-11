namespace SwedbankPay.Sdk.Payments.SwishPayments
{
    public class SwishPaymentSaleRequest
    {
        public SwishPaymentSaleRequest(Msisdn msisdn)
        {
            Transaction = new SwishPaymentSaleTransaction(msisdn);
        }


        public SwishPaymentSaleTransaction Transaction { get; }
    }
}
