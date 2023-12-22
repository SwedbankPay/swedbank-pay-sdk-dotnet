using SwedbankPay.Sdk.Infrastructure.Extensions;
using SwedbankPay.Sdk.Infrastructure.PaymentOrder.OperationRequest.RemoveToken;
using SwedbankPay.Sdk.PaymentOrder;
using SwedbankPay.Sdk.PaymentOrder.OperationRequest.RemoveToken;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder;

internal class UserTokenOperations : OperationsBase, IUserTokenOperations
{
    internal UserTokenOperations(IOperationList httpOperations, HttpClient httpClient)
    {
        foreach (var httpOperation in httpOperations)
        {
            switch (httpOperation.Rel.Value)
            {
                case PaymentOrderResourceOperations.DeleteAllTokens:
                    DeleteAllTokens = async payload =>
                    {
                        var url = httpOperation.Href;
                        var requestDto = new RemoveTokenRequestDto(payload);
                        var paymentOrderResponseContainer = await httpClient.SendAsJsonAsync<UserTokenResponseDto>(httpOperation.Method, url, requestDto);
                        return paymentOrderResponseContainer != null ? new UserTokenResponse(paymentOrderResponseContainer, httpClient) : null;
                    };
                    break;
                case PaymentOrderResourceOperations.DeleteTokens:
                    DeleteTokens = async payload =>
                    {
                        var url = httpOperation.Href;
                        var requestDto = new RemoveTokenRequestDto(payload);
                        var paymentOrderResponseContainer = await httpClient.SendAsJsonAsync<UserTokenResponseDto>(httpOperation.Method, url, requestDto);
                        return paymentOrderResponseContainer != null ? new UserTokenResponse(paymentOrderResponseContainer, httpClient) : null;
                    };
                    break;
                case PaymentOrderResourceOperations.DeleteRecurringTokens:
                    DeleteRecurringTokens = async payload =>
                    {
                        var url = httpOperation.Href;
                        var requestDto = new RemoveTokenRequestDto(payload);
                        var paymentOrderResponseContainer = await httpClient.SendAsJsonAsync<UserTokenResponseDto>(httpOperation.Method, url, requestDto);
                        return paymentOrderResponseContainer != null ? new UserTokenResponse(paymentOrderResponseContainer, httpClient) : null;
                    };
                    break;
            }
            
            Add(httpOperation.Rel, httpOperation);
        }
    }
    
    public Func<RemoveTokenRequest, Task<IUserTokenResponse?>>? DeleteAllTokens { get; }
    public Func<RemoveTokenRequest, Task<IUserTokenResponse?>>? DeleteTokens { get; }
    public Func<RemoveTokenRequest, Task<IUserTokenResponse?>>? DeleteRecurringTokens { get; }

}