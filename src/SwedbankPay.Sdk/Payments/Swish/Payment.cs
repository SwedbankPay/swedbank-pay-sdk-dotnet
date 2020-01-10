using System;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments.Swish
{
    public class Payment
    {
        private Payment(PaymentResponse paymentResponse, SwedbankPayHttpClient client)
        {
            PaymentResponse = paymentResponse.Payment;
            var operations = new Operations();

            foreach (var httpOperation in paymentResponse.Operations)
            {
                operations.Add(httpOperation.Rel, httpOperation);

                switch (httpOperation.Rel.Value)
                {
                    case PaymentResourceOperations.UpdatePaymentAbort:
                        operations.Abort = async () =>
                            await client.SendHttpRequestAndProcessHttpResponse<PaymentResponse>(
                                httpOperation.Request.AttachPayload(new PaymentAbortRequest()));
                        break;

                    case PaymentResourceOperations.CreateSale:
                        operations.CreateSale = async payload =>
                            await client.SendHttpRequestAndProcessHttpResponse<SaleResponse>(httpOperation.Request.AttachPayload(payload));
                        break;
                    case PaymentResourceOperations.RedirectSale:
                        operations.RedirectSale = httpOperation;
                        break;

                    case PaymentResourceOperations.ViewSales:
                        operations.ViewSales = httpOperation;
                        break;
                    case PaymentResourceOperations.CreateReversal:
                        operations.CreateReversal = async payload =>
                            await client.SendHttpRequestAndProcessHttpResponse<ReversalResponse>(
                                httpOperation.Request.AttachPayload(payload));
                        break;
                    case PaymentResourceOperations.PaidPayment:
                        operations.PaidPayment = httpOperation;
                        break;
                }
            }

            Operations = operations;
        }


        public Operations Operations { get; }

        public PaymentResponseObject PaymentResponse { get; }


        internal static async Task<Payment> Create(PaymentRequest paymentRequest,
                                                   SwedbankPayHttpClient client,
                                                   string paymentExpand)
        {
            var url = new Uri($"/psp/swish/payments{paymentExpand}", UriKind.Relative);

            var paymentResponse = await client.HttpPost<PaymentResponse>(url, paymentRequest);
            return new Payment(paymentResponse, client);
        }


        internal static async Task<Payment> Get(Uri id, SwedbankPayHttpClient client, string paymentExpand)
        {
            var url = !string.IsNullOrWhiteSpace(paymentExpand)
                ? new Uri(id.OriginalString + paymentExpand, UriKind.RelativeOrAbsolute)
                : id;

            var paymentResponse = await client.HttpGet<PaymentResponse>(url);
            return new Payment(paymentResponse, client);
        }
    }
}