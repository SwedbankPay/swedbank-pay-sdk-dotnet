using SwedbankPay.Sdk.Extensions;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
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
                Add(httpOperation.Rel, httpOperation);

            }
        }
        public Func<PaymentAbortRequest, Task<IMobilePayPaymentResponse>> Abort { get; }
        public Func<MobilePayPaymentCancelRequest, Task<ICancellationResponse>> Cancel { get; }
        public Func<MobilePayPaymentCaptureRequest, Task<ICaptureResponse>> Capture { get; }
        public HttpOperation RedirectAuthorization { get; }
        public Func<MobilePayPaymentReversalRequest, Task<IReversalResponse>> Reverse { get; }
        public HttpOperation ViewAuthorization { get; }
    }
}
