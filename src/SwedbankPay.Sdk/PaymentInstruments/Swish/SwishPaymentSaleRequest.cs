namespace SwedbankPay.Sdk.PaymentInstruments.Swish
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
