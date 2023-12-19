using SwedbankPay.Sdk.Extensions;
using SwedbankPay.Sdk.PaymentOrder.OperationRequest.Abort;
using SwedbankPay.Sdk.PaymentOrder.OperationRequest.Cancel;
using SwedbankPay.Sdk.PaymentOrder.OperationRequest.Capture;
using SwedbankPay.Sdk.PaymentOrder.OperationRequest.Reversal;
using SwedbankPay.Sdk.PaymentOrder.OperationRequest.Update;

namespace SwedbankPay.Sdk.PaymentOrder;

internal class PaymentOrderOperations : OperationsBase, IPaymentOrderOperations
{
    internal PaymentOrderOperations(IOperationList httpOperations, HttpClient httpClient)
    {
        foreach (var httpOperation in httpOperations)
        {
            switch (httpOperation.Rel.Value)
            {
                case PaymentOrderResourceOperations.UpdateOrder:
                    Update = async payload =>
                    {
                        var url = httpOperation.Href.GetUrlWithQueryString(PaymentOrderExpand.All);
                        var requestDto = new PaymentOrderUpdateRequestDto(payload);
                        var paymentOrderResponseContainer = await httpClient.SendAsJsonAsync<PaymentOrderResponseDto>(httpOperation.Method, url, requestDto);
                        return paymentOrderResponseContainer != null ? new PaymentOrderResponse(paymentOrderResponseContainer, httpClient) : null;
                    };
                    break;
                case PaymentOrderResourceOperations.Abort:
                    Abort = async payload =>
                    {
                        var url = httpOperation.Href.GetUrlWithQueryString(PaymentOrderExpand.All);
                        var requestDto = new PaymentOrderAbortRequestDto(payload);
                        var paymentOrderResponseContainer = await httpClient.SendAsJsonAsync<PaymentOrderResponseDto>(httpOperation.Method, url, requestDto);
                        return paymentOrderResponseContainer != null ? new PaymentOrderResponse(paymentOrderResponseContainer, httpClient) : null;
                    };
                    break;
                case PaymentOrderResourceOperations.Cancel:
                    Cancel = async payload =>
                    {
                        var requestDto = new PaymentOrderCancelRequestDto(payload);
                        var url = httpOperation.Href.GetUrlWithQueryString(PaymentOrderExpand.All);
                        var dto = await httpClient.SendAsJsonAsync<PaymentOrderResponseDto>(httpOperation.Method, url, requestDto);
                        return dto != null ? new PaymentOrderResponse(dto, httpClient) : null;
                    };
                    break;
                case PaymentOrderResourceOperations.Capture:
                    Capture = async payload =>
                    {
                        var requestDto = new PaymentOrderCaptureRequestDto(payload);
                        var url = httpOperation.Href.GetUrlWithQueryString(PaymentOrderExpand.All);
                        var dto = await httpClient.SendAsJsonAsync<PaymentOrderResponseDto>(httpOperation.Method, url, requestDto);
                        return dto != null ? new PaymentOrderResponse(dto, httpClient) : null;
                    };
                    break;
                case PaymentOrderResourceOperations.Reversal:
                    Reverse = async payload =>
                    {
                        var url = httpOperation.Href.GetUrlWithQueryString(PaymentOrderExpand.All);
                        var requestDto = new PaymentOrderReversalRequestDto(payload);
                        var dto = await httpClient.SendAsJsonAsync<PaymentOrderResponseDto>(httpOperation.Method, url, requestDto);
                        return dto != null ? new PaymentOrderResponse(dto, httpClient) : null;
                    };
                    break;
                case PaymentOrderResourceOperations.RedirectCheckout:
                    Redirect = httpOperation;
                    break;
                case PaymentOrderResourceOperations.ViewCheckout:
                    View = httpOperation;
                    break;
            }

            Add(httpOperation.Rel, httpOperation);
        }
    }

    public Func<PaymentOrderAbortRequest, Task<IPaymentOrderResponse?>>? Abort { get; }
    public Func<PaymentOrderUpdateRequest, Task<IPaymentOrderResponse?>>? Update { get; }
    public Func<PaymentOrderCancelRequest, Task<IPaymentOrderResponse?>>? Cancel { get; }
    public Func<PaymentOrderCaptureRequest, Task<IPaymentOrderResponse?>>? Capture { get; }
    public Func<PaymentOrderReversalRequest, Task<IPaymentOrderResponse?>>? Reverse { get; }
    public HttpOperation? Redirect { get; }
    public HttpOperation? View { get; }
}