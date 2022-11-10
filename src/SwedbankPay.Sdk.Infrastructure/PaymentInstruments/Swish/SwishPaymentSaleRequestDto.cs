namespace SwedbankPay.Sdk.PaymentInstruments.Swish;

internal class SwishPaymentSaleRequestDto
{
    public SwishPaymentSaleRequestDto(SwishPaymentSaleRequest payload)
    {
        Transaction = new SwishPaymentSaleTransactionDto(payload.Transaction);
    }

    public SwishPaymentSaleTransactionDto Transaction { get; }
}