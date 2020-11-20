using SwedbankPay.Sdk.Extensions;
using SwedbankPay.Sdk.PaymentInstruments.Card;
using SwedbankPay.Sdk.PaymentOrders;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    public class VippsPaymentOperations : OperationsBase, IVippsPaymentOperations
    {
        public VippsPaymentOperations(IOperationList operations, HttpClient client)
        {
            foreach (var httpOperation in operations)
            {
                switch (httpOperation.Rel.Value)
                {
                    case PaymentResourceOperations.ViewAuthorization:
                        ViewAuthorization = httpOperation;
                        break;

                    case PaymentResourceOperations.DirectAuthorization:
                        DirectAuthorization = async payload => {
                            var dto = await client.SendAsJsonAsync<VippsPaymentAuthorizationResponseDto>(httpOperation.Method, httpOperation.Href, payload);
                            return new VippsPaymentAuthorizationResponse(dto.Payment, dto.Authorization.Map());
                        };
                        break;

                    case PaymentResourceOperations.CreateCapture:
                        Capture = async payload => {
                            var dto = await client.SendAsJsonAsync<CaptureResponseDto>(httpOperation.Method, httpOperation.Href, payload);
                            return new CaptureResponse(dto.payment, dto.Capture.Map());
                        };
                        break;

                    case PaymentResourceOperations.CreateCancellation:
                        Cancel = async payload => {
                            var dto = await client.SendAsJsonAsync<CancellationResponseDto>(httpOperation.Method, httpOperation.Href, payload);
                            return new CancellationResponse(dto.Payment, dto.Cancellation.Map());
                        };
                        break;

                    case PaymentResourceOperations.CreateReversal:
                        Reversal = async payload => {
                            var dto = await client.SendAsJsonAsync<ReversalResponseDto>(httpOperation.Method, httpOperation.Href, payload);
                            return new ReversalResponse(dto.Payment, dto.Reversal.Map());
                        };
                        break;
                }
                Add(httpOperation.Rel, httpOperation);
            }
        }

        public Func<VippsPaymentCancelRequest, Task<CancellationResponse>> Cancel { get; }
        public Func<VippsPaymentCaptureRequest, Task<CaptureResponse>> Capture { get; }
        public Func<VippsPaymentAuthorizationRequest, Task<IVippsPaymentAuthorizationResponse>> DirectAuthorization { get; }
        public Func<VippsPaymentReversalRequest, Task<IReversalResponse>> Reversal { get; }
        public HttpOperation RedirectAuthorization { get; }
        public HttpOperation Update { get; }
        public HttpOperation ViewAuthorization { get; }
    }
}


