using swedbankpay.sdk.Payments.Vipps;
using System;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments.Invoice
{
    public class Payment
    {
        private Payment(PaymentResponse paymentResponse, SwedbankPayHttpClient client)
        {
            PaymentResponse = paymentResponse.Payment;
            var operations = new VippsPaymentOperations();

            foreach (var httpOperation in paymentResponse.Operations)
            {
                operations.Add(httpOperation.Rel, httpOperation);

                switch (httpOperation.Rel.Value)
                {
                    case PaymentResourceOperations.UpdatePaymentAbort:
                        operations.Update = httpOperation;
                        break;

                    case PaymentResourceOperations.RedirectAuthorization:
                        operations.RedirectAuthorization = httpOperation;
                        break;

                    case PaymentResourceOperations.ViewAuthorization:
                        operations.ViewAuthorization = httpOperation;
                        break;

                    case PaymentResourceOperations.CreateCapture:
                        operations.Capture = async payload =>
                            await client.SendHttpRequestAndProcessHttpResponse<CaptureResponse>(
                                httpOperation.Request.AttachPayload(payload));
                        break;

                    case PaymentResourceOperations.CreateCancellation:
                        operations.Cancel = async payload =>
                            await client.SendHttpRequestAndProcessHttpResponse<CancellationResponse>(
                                httpOperation.Request.AttachPayload(payload));
                        break;

                    case PaymentResourceOperations.CreateReversal:
                        operations.Reversal = async payload =>
                            await client.SendHttpRequestAndProcessHttpResponse<ReversalResponse>(
                                httpOperation.Request.AttachPayload(payload));
                        break;

                }
            }
            Operations = operations;
        }

        public VippsPaymentOperations Operations { get; }

        public PaymentResponseObject PaymentResponse { get; }


        internal static async Task<Payment> Create(PaymentRequest paymentRequest,
                                                   SwedbankPayHttpClient client,
                                                   string paymentExpand)
        {
            var url = new Uri($"/psp/vipps/payments{paymentExpand}", UriKind.Relative);

            var paymentResponse = await client.HttpPost<PaymentResponse>(url, paymentRequest);
            return new Payment(paymentResponse, client);
        }


        internal static async Task<Payment> Get(Uri id, SwedbankPayHttpClient client, string paymentExpand)
        {
            var url = !string.IsNullOrWhiteSpace(paymentExpand)
                ? new Uri(id.OriginalString + paymentExpand, UriKind.RelativeOrAbsolute)
                : id;

            var paymentResponseContainer = await client.HttpGet<PaymentResponse>(url);
            return new Payment(paymentResponseContainer, client);
        }
    }
}