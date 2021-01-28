using SwedbankPay.Sdk.Extensions;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    internal class MobilePayPaymentOperations : OperationsBase, IMobilePayPaymentOperations
    {
        public MobilePayPaymentOperations(IOperationList operations, HttpClient client)
        {
            foreach (var httpOperation in operations)
            {
                switch (httpOperation.Rel.Value)
                {
                    case PaymentResourceOperations.UpdatePaymentAbort:
                        Abort = async payload => {
                            var requestDto = new PaymentAbortRequestDto(payload);
                            var responseDto = await client.SendAsJsonAsync<MobilePayPaymentResponseDto>(httpOperation.Method, httpOperation.Href, requestDto);
                            return new MobilePayPaymentResponse(responseDto, client);
                        };
                        break;

                    case PaymentResourceOperations.RedirectAuthorization:
                        RedirectAuthorization = httpOperation;
                        break;

                    case PaymentResourceOperations.ViewAuthorization:
                        ViewAuthorization = httpOperation;
                        break;

                    case PaymentResourceOperations.CreateCapture:
                        Capture = async payload => {
                            var requestDto = new MobilePayPaymentCaptureRequestDto(payload);
                            var responseDto = await client.SendAsJsonAsync<CaptureResponseDto>(httpOperation.Method, httpOperation.Href, requestDto);
                            return new CaptureResponse(responseDto);
                        };
                        break;

                    case PaymentResourceOperations.CreateCancellation:
                        Cancel = async payload => {
                            var requestDto = new MobilePayPaymentCancelRequestDto(payload);
                            return await client.SendAsJsonAsync<CancellationResponse>(httpOperation.Method, httpOperation.Href, requestDto);
                        };
                        break;

                    case PaymentResourceOperations.CreateReversal:
                        Reverse = async payload => {
                            var requestDto = new MobilePayPaymentReversalRequestDto(payload);
                            return await client.SendAsJsonAsync<ReversalResponse>(httpOperation.Method, httpOperation.Href, requestDto);
                        };
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
