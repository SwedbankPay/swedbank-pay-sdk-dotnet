using System;
using System.Threading.Tasks;
using SwedbankPay.Sdk;
using SwedbankPay.Sdk.Payments.VippsPayments;
using SwedbankPay.Sdk.Payments;
using System.Net.Http;
using SwedbankPay.Sdk.Extensions;

namespace swedbankpay.Sdk.Payments.VippsPayments
{
    public class VippsPaymentOperations : OperationsBase
    {
        public VippsPaymentOperations(OperationList operations, HttpClient client)
        {
            foreach (var httpOperation in operations)
            {
                switch (httpOperation.Rel.Value)
                {
                    case PaymentResourceOperations.ViewAuthorization:
                        ViewAuthorization = httpOperation;
                        break;

                    case PaymentResourceOperations.DirectAuthorization:
                        DirectAuthorization = async payload =>
                            await client.SendAsJsonAsync<VippsPaymentAuthorizationResponse>(httpOperation.Method, httpOperation.Href, payload);
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
                        Reversal = async payload =>
                            await client.SendAsJsonAsync<ReversalResponse>(httpOperation.Method, httpOperation.Href, payload);
                        break;
                }
                this.Add(httpOperation.Rel, httpOperation);
            }
        }

        public Func<VippsPaymentCancelRequest, Task<CancellationResponse>> Cancel { get; }
        public Func<VippsPaymentCaptureRequest, Task<CaptureResponse>> Capture { get; }
        public Func<VippsPaymentAuthorizationRequest, Task<VippsPaymentAuthorizationResponse>> DirectAuthorization { get; }
        public Func<VippsPaymentReversalRequest, Task<ReversalResponse>> Reversal { get; }
        public HttpOperation RedirectAuthorization { get; }
        public HttpOperation Update { get; }
        public HttpOperation ViewAuthorization { get; }
    }
}


