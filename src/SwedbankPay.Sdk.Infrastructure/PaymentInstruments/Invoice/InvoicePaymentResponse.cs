using SwedbankPay.Sdk.Extensions;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using SwedbankPay.Sdk.Payments.InvoicePayments;
using Swedbankpay.Sdk.Payments;

namespace SwedbankPay.Sdk.Payments
{
    public class InvoicePaymentResponse : IInvoicePaymentResponse
    {
        public InvoicePaymentResponse(InvoicePaymentResponseDto paymentResponseContainer, HttpClient httpClient)
        {
            Operations = new InvoicePaymentOperations(paymentResponseContainer.Operations.Map(), httpClient);
            Payment = new InvoicePayment(paymentResponseContainer.Payment);
        }

        public IInvoicePaymentOperations Operations { get; }

        public IInvoicePayment Payment { get; }
    }
}