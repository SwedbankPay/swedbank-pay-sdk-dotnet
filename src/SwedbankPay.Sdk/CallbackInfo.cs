namespace SwedbankPay.Sdk;

public record CallbackInfo
{
    public string? OrderReference { get; init; }
    public PaymentOrderInfo? PaymentOrder { get; init; }
}

public record PaymentOrderInfo
{
    public Uri? Id { get; init; }

    public string? Instrument { get; init; }

    public long Number { get; init; }
}