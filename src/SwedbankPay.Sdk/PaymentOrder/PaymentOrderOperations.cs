using SwedbankPay.Sdk.Extensions;
using SwedbankPay.Sdk.PaymentOrder.OperationRequest;

namespace SwedbankPay.Sdk.PaymentOrder;

public interface IPaymentOrderOperations : IDictionary<LinkRelation, HttpOperation?>
{
    /// <summary>
    /// Updates the contents of the payment order, if available.
    /// </summary>
    Func<PaymentOrderUpdateRequest, Task<IPaymentOrderResponse?>>? Update { get; }
 
    /// <summary>
    /// Aborts the payment order, if available.
    /// </summary>
    Func<PaymentOrderAbortRequest, Task<IPaymentOrderResponse?>>? Abort { get; }
    
    Func<PaymentOrderCancelRequest, Task<IPaymentOrderResponse?>>? Cancel { get; }
    
    Func<PaymentOrderCaptureRequest, Task<IPaymentOrderResponse?>>? Capture { get; }
    
    Func<PaymentOrderReversalRequest, Task<IPaymentOrderResponse?>>? Reverse { get; }
    
    HttpOperation? Redirect { get; }
    
    /// <summary>
    /// Returns details needed to created a hosted view for the payer to see the payment order, if available.
    /// </summary>
    HttpOperation? View { get; }
}

public class PaymentOrderOperations : OperationsBase, IPaymentOrderOperations
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
                        var paymentOrderResponseContainer =
                            await httpClient.SendAsJsonAsync<PaymentOrderResponseDto>(httpOperation.Method, url,
                                requestDto);
                        return paymentOrderResponseContainer != null ? new PaymentOrderResponse(paymentOrderResponseContainer, httpClient) : null;
                    };
                    break;
                case PaymentOrderResourceOperations.Abort:
                    Abort = async payload =>
                    {
                        var url = httpOperation.Href.GetUrlWithQueryString(PaymentOrderExpand.All);
                        var requestDto = new PaymentOrderAbortRequestDto(payload);
                        var paymentOrderResponseContainer =
                            await httpClient.SendAsJsonAsync<PaymentOrderResponseDto>(httpOperation.Method, url, requestDto);
                        return paymentOrderResponseContainer != null ? new PaymentOrderResponse(paymentOrderResponseContainer, httpClient) : null;
                    };
                    break;
                case PaymentOrderResourceOperations.Cancel:
                    Cancel = async payload =>
                    {
                        var requestDto = new PaymentOrderCancelRequestDto(payload);
                        var dto = await httpClient.SendAsJsonAsync<PaymentOrderResponseDto>(httpOperation.Method,
                            httpOperation.Href, requestDto);
                        return dto != null ? new PaymentOrderResponse(dto, httpClient) : null;
                    };
                    break;
                case PaymentOrderResourceOperations.Capture:
                    Capture = async payload =>
                    {
                        var requestDto = new PaymentOrderCaptureRequestDto(payload);
                        var dto = await httpClient.SendAsJsonAsync<PaymentOrderResponseDto>(httpOperation.Method,
                            httpOperation.Href, requestDto);
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