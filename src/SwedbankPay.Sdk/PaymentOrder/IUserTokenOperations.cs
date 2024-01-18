using SwedbankPay.Sdk.PaymentOrder.OperationRequest.RemoveToken;

namespace SwedbankPay.Sdk.PaymentOrder;

public interface IUserTokenOperations
{
    Func<RemoveTokenRequest, Task<IUserTokenResponse?>>? DeleteAllTokens { get; }
    Func<RemoveTokenRequest, Task<IUserTokenResponse?>>? DeleteTokens { get; }
    Func<RemoveTokenRequest, Task<IUserTokenResponse?>>? DeleteRecurringTokens { get; }
    Func<RemoveTokenRequest, Task<IUserTokenResponse?>>? DeleteUnscheduledTokens { get; }
}