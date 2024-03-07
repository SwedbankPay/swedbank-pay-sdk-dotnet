namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder;

internal record UserTokenResponseDto
{
    public UserTokenListResponseDto PayerOwnedTokens { get; init; } = null!;
    public OperationListDto? Operations { get; init; } = null!;
}
