using System.Collections.Generic;


namespace SwedbankPay.Sdk.Payments.InvoicePayments
{
    public class InvoicePaymentCaptureRequest
    {
        public InvoicePaymentCaptureRequest(ICaptureTransaction transaction)
        {
            Transaction = transaction;
        }


        public ICaptureTransaction Transaction { get; }
    }
}