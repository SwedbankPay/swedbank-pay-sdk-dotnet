using Swedbankpay.Sdk.Payments;

namespace SwedbankPay.Sdk.Payments
{
    public class InvoicePaymentResponseDto
    {
        public InvoicePaymentOperationsDto Operations { get; internal set; }

        public InvoicePaymentDto Payment { get; set; }
    }
}