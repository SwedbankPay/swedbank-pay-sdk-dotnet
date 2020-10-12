using SwedbankPay.Sdk.Extensions;
using SwedbankPay.Sdk.Payments.InvoicePayments;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments
{
    public class InvoicePaymentsResource : ResourceBase, IInvoiceResource
    {
        public InvoicePaymentsResource(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<IInvoicePaymentResponse> Get(Uri id, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            var url = id.GetUrlWithQueryString(paymentExpand);

            var paymentResponseContainer = await HttpClient.GetAsJsonAsync<InvoicePaymentResponseDto>(url);
            return new InvoicePaymentResponse(paymentResponseContainer, HttpClient);
        }

        public async Task<IInvoicePaymentResponse> Create(InvoicePaymentRequest paymentRequest,
                                           PaymentExpand paymentExpand = PaymentExpand.None)
        {
            var url = new Uri($"/psp/invoice/payments{paymentExpand}", UriKind.Relative);

            var paymentResponse = await HttpClient.PostAsJsonAsync<InvoicePaymentResponseDto>(url, paymentRequest);
            return new InvoicePaymentResponse(paymentResponse, HttpClient);
        }
    }
}
