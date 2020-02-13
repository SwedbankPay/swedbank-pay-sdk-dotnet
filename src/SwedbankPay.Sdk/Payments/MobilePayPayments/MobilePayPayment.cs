using swedbankpay.sdk.Payments.MobilePayPayments;
using System;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments.MobilePayPayments
{
    public class MobilePayPayment
    {
        private MobilePayPayment(MobilePayPaymentResponse paymentResponse, SwedbankPayHttpClient client)
        {
            PaymentResponse = paymentResponse.Payment;
            var operations = new MobilePayOperations();

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

        public MobilePayOperations Operations { get; }

        public PaymentResponseObject PaymentResponse { get; }


        internal static async Task<MobilePayPayment> Create(MobilePayPaymentRequest paymentRequest,
                                                   SwedbankPayHttpClient client,
                                                   string paymentExpand)
        {
            var url = new Uri($"/psp/mobilepay/payments{paymentExpand}", UriKind.Relative);

            var paymentResponse = await client.HttpPost<MobilePayPaymentResponse>(url, paymentRequest);
            return new MobilePayPayment(paymentResponse, client);
        }


        internal static async Task<MobilePayPayment> Get(Uri id, SwedbankPayHttpClient client, string paymentExpand)
        {
            var url = !string.IsNullOrWhiteSpace(paymentExpand)
                ? new Uri(id.OriginalString + paymentExpand, UriKind.RelativeOrAbsolute)
                : id;

            var paymentResponseContainer = await client.HttpGet<MobilePayPaymentResponse>(url);
            return new MobilePayPayment(paymentResponseContainer, client);
        }
    }
}