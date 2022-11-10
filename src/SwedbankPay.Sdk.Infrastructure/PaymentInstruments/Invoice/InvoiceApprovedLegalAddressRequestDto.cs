namespace SwedbankPay.Sdk.PaymentInstruments.Invoice;

internal class InvoiceApprovedLegalAddressRequestDto
{
    public InvoiceApprovedLegalAddressRequestDto(InvoiceApprovedLegalAddressRequest payload)
    {
        Addressee = new ApprovedLegalAddressRequestDto(payload.Addressee);
    }

    public ApprovedLegalAddressRequestDto Addressee { get; }
}