using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder;

internal record UserTokenResponseItemDto
{
    public string? Token { get; init; }
    public string? TokenType { get; init; }
    public string? Instrument { get; init; }
    public string? InstrumentDisplayName { get; init; }
    public string? CorrelationId { get; init; }
    public InstrumentParametersDto? InstrumentParameters { get; init; }
    public OperationListDto? Operations { get; init; }

    public IUserToken Map(HttpClient httpClient)
    {
        var dto = new UserTokenDto
        {
            Token = Token,
            TokenType = TokenType,
            Instrument = Instrument,
            InstrumentDisplayName = InstrumentDisplayName,
            CorrelationId = CorrelationId,
            InstrumentParameters = InstrumentParameters
        };
        
        if (Operations != null) {
            dto.Operations = new UserTokenOperations(Operations?.Map()!, httpClient);
        }

        return dto;
    }
}