namespace SwedbankPay.Sdk.PaymentInstruments.Trustly
{
    internal class TrustlyPaymentCancelRequestDto
    {
        public TrustlyPaymentCancelRequestDto(TrustlyPaymentCancelRequest payload)
        {
            Transaction = new CancelTransactionDto(payload.Transaction);
        }

        public CancelTransactionDto Transaction { get; }
    }
}