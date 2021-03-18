namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    internal class SwishPaymentSaleTransactionDto
    {
        public SwishPaymentSaleTransactionDto(SwishPaymentSaleTransaction transaction)
        {
            if (transaction == null)
            {
                return;
            }

            Msisdn = transaction.Msisdn?.ToString();
        }

        public string Msisdn { get; }
    }
}