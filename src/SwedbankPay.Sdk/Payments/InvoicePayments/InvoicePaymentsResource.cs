using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments.InvoicePayments
{
    public class InvoicePaymentsResource : ResourceBase, IInvoicePaymentsResource
    {
        public InvoicePaymentsResource(HttpClient httpClient) : base(httpClient)
        {
        }

        public Task<InvoicePayment> Get(Uri id, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return InvoicePayment.Get(id, this.httpClient, GetExpandQueryString(paymentExpand));
        }

        public Task<InvoicePayment> Create(InvoicePaymentRequest paymentRequest,
                                                            PaymentExpand paymentExpand = PaymentExpand.None)
        {
            return InvoicePayment.Create(paymentRequest, this.httpClient, GetExpandQueryString(paymentExpand));
        }
    }
}
