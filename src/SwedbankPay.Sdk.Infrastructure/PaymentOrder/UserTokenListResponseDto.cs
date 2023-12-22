namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder;
internal record UserTokenListResponseDto
{
    public string? Id { get; init; }
    public string? PayerReference { get; init; }
    public List<UserTokenResponseItemDto>? Tokens { get; init; }
}