using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder;

internal record UserTokenDto : IUserToken
{
    public string? Token { get; init; }
    public string? TokenType { get; init; }
    public string? Instrument { get; init; }
    public string? InstrumentDisplayName { get; init; }
    public string? CorrelationId { get; init; }
    public IInstrumentParameters? InstrumentParameters { get; init; }
    public IUserTokenOperations? Operations { get; set; }
}