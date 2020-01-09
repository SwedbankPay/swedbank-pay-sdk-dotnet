using System;
using System.Threading.Tasks;

using SwedbankPay.Sdk.Transactions;

namespace SwedbankPay.Sdk.Payments.Swish
{
    public class Payment
    {
        private Payment(PaymentResponseContainer<PaymentResponse> paymentResponseContainer, SwedbankPayHttpClient client)
        {
            PaymentResponse = paymentResponseContainer.PaymentResponse;
            var operations = new Operations();

            foreach (var httpOperation in paymentResponseContainer.Operations)
            {
                operations.Add(httpOperation.Rel, httpOperation);

                switch (httpOperation.Rel.Value)
                {
                    case PaymentResourceOperations.UpdatePaymentAbort:
                        operations.Abort = async () => await client.SendHttpRequestAndProcessHttpResponse<PaymentResponseContainer<PaymentResponse>>(httpOperation.Request.AttachPayload(new PaymentAbortRequest()));
                        break;

                    case PaymentResourceOperations.CreateSale:
                        operations.CreateSale = async payload => await client.SendHttpRequestAndProcessHttpResponse<SaleResponse>(httpOperation.Request.AttachPayload(payload));
                        break;
                    case PaymentResourceOperations.RedirectSale:
                        operations.RedirectSale = httpOperation;
                        break;

                    case PaymentResourceOperations.ViewSales:
                        operations.ViewSales = httpOperation;
                        break;
                    case PaymentResourceOperations.CreateReversal:
                        operations.CreateReversal = async payload => await client.SendHttpRequestAndProcessHttpResponse<ReversalResponse>(httpOperation.Request.AttachPayload(payload));
                        break;
                    case PaymentResourceOperations.PaidPayment:
                        operations.PaidPayment = httpOperation;
                        break;
                }
            }

            Operations = operations;
        }


        public Operations Operations { get; }

        public PaymentResponse PaymentResponse { get; }


        internal static async Task<Payment> Create(PaymentRequest paymentRequest,
                                                   SwedbankPayHttpClient client,
                                                   string paymentExpand)
        {
            var url = new Uri($"/psp/swish/payments{paymentExpand}", UriKind.Relative);

            var paymentResponseContainer = await client.HttpPost<PaymentResponseContainer<PaymentResponse>>(url, paymentRequest);
            return new Payment(paymentResponseContainer, client);
        }




        internal static async Task<Payment> Get(Uri id, SwedbankPayHttpClient client, string paymentExpand)
        {
            var url = !string.IsNullOrWhiteSpace(paymentExpand)
                ? new Uri(id.OriginalString + paymentExpand, UriKind.RelativeOrAbsolute)
                : id;

            var paymentResponseContainer = await client.HttpGet<PaymentResponseContainer<PaymentResponse>>(url);
            return new Payment(paymentResponseContainer, client);
        }
    }
}