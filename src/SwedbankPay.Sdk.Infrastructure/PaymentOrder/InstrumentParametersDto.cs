using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder;

public class InstrumentParametersDto : IInstrumentParameters
{
    public string? ExpiryDate { get; init; }
    public string? CardBrand { get; init; }
    public string? Email { get; init; }
    public string? Msisdn { get; init; }
    public string? ZipCode { get; init; }
}