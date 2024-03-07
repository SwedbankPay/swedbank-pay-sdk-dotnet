using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder;

internal record InstrumentParametersResponseDto
{
    public string? AccountId { get; init; }
    public string? Bank { get; init; }
    public string? ClearingHouse { get; init; }
    public bool DirectDebitEnabled { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? ExpiryDate { get; init; }
    public string? IssuerName { get; init; }
    public DateTime? ExpiryPan { get; init; }
    public DateTime? ExpiryDPan { get; init; }
    public string? CardBrand { get; init; }
    public string? Email { get; init; }
    public string? Msisdn { get; init; }
    public string? ZipCode { get; init; }
    public string? LastFourPan { get; init; }
    public string? LastFourDPan { get; init; }

    public IInstrumentParameters Map()
    {
        return new InstrumentParameters(this);
    }
}