using SwedbankPay.Sdk.Payments.InvoicePayments;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments
{
    public class InvoicePaymentsResource : ResourceBase, IInvoicePaymentsResource
    {
        public InvoicePaymentsResource(HttpClient httpClient) : base(httpClient)
        {
        }

        public Task<IInvoicePayment> Get(Uri id, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return InvoicePayment.Get(id, this.HttpClient, GetExpandQueryString(paymentExpand));
        }

        public Task<IInvoicePayment> Create(InvoicePaymentRequest paymentRequest,
                                           PaymentExpand paymentExpand = PaymentExpand.None)
        {
            return InvoicePayment.Create(paymentRequest, this.HttpClient, GetExpandQueryString(paymentExpand));
        }
    }
}
