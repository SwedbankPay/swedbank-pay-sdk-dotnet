using SwedbankPay.Sdk.PaymentOrder;
using SwedbankPay.Sdk.PaymentOrder.Paid;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder;

internal record UserTokenDto : IUserToken
{
    public bool? IsDeleted { get; init; }
    public string? Token { get; init; }
    public string? TokenType { get; init; }
    public PaymentInstrument? Instrument { get; init; }
    public string? InstrumentDisplayName { get; init; }
    public string? CorrelationId { get; init; }
    public IInstrumentParameters? InstrumentParameters { get; init; }
    public IUserTokenOperations? Operations { get; set; }
}