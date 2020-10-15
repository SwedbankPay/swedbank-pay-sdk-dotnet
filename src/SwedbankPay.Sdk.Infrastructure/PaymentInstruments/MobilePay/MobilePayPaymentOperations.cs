using System;
using System.Threading.Tasks;
using SwedbankPay.Sdk;
using SwedbankPay.Sdk.Payments.MobilePayPayments;
using System.Net.Http;
using SwedbankPay.Sdk.Extensions;
using SwedbankPay.Sdk.PaymentInstruments.MobilePay;
using SwedbankPay.Sdk.PaymentInstruments;

namespace Swedbankpay.Sdk.Payments
{
    public class MobilePayPaymentOperations : OperationsBase, IMobilePayPaymentOperations
    {
        public MobilePayPaymentOperations(IOperationList operations, HttpClient client)
        {
            foreach (var httpOperation in operations)
            {
                switch (httpOperation.Rel.Value)
                {
                    case PaymentResourceOperations.UpdatePaymentAbort:
                        Abort = async payload =>
                            await client.SendAsJsonAsync<MobilePayPaymentResponse>(httpOperation.Method, httpOperation.Href, payload);
                        break;

                    case PaymentResourceOperations.RedirectAuthorization:
                        RedirectAuthorization = httpOperation;
                        break;

                    case PaymentResourceOperations.ViewAuthorization:
                        ViewAuthorization = httpOperation;
                        break;

                    case PaymentResourceOperations.CreateCapture:
                        Capture = async payload =>
                            await client.SendAsJsonAsync<CaptureResponse>(httpOperation.Method, httpOperation.Href, payload);
                        break;

                    case PaymentResourceOperations.CreateCancellation:
                        Cancel = async payload =>
                            await client.SendAsJsonAsync<CancellationResponse>(httpOperation.Method, httpOperation.Href, payload);
                        break;

                    case PaymentResourceOperations.CreateReversal:
                        Reverse = async payload =>
                            await client.SendAsJsonAsync<ReversalResponse>(httpOperation.Method, httpOperation.Href, payload);
                        break;
                }
                this.Add(httpOperation.Rel, httpOperation);

            }
        }
        public Func<PaymentAbortRequest, Task<IMobilePayPaymentResponse>> Abort { get; }
        public Func<MobilePayPaymentCancelRequest, Task<CancellationResponse>> Cancel { get; }
        public Func<MobilePayPaymentCaptureRequest, Task<CaptureResponse>> Capture { get; }
        public HttpOperation RedirectAuthorization { get; }
        public Func<MobilePayPaymentReversalRequest, Task<ReversalResponse>> Reverse { get; }
        public HttpOperation ViewAuthorization { get; }
    }
}
