using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public class InvoicePaymentAuthorizationResponseDto
    {
        public InvoicePaymentAuthorizationDto Authorization { get; set; }
        public Uri Payment { get; set; }

        public IInvoicePaymentAuthorization Map()
        {
            return new InvoicePaymentAuthorization(Payment, Authorization);
        }
    }
}