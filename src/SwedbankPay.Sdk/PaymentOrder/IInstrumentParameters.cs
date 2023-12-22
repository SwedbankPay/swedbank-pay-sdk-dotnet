namespace SwedbankPay.Sdk.PaymentOrder;

public interface IInstrumentParameters
{
    string? ExpiryDate { get; init; }
    string? CardBrand { get; init; }
    string? Email { get; init; }
    string? Msisdn { get; init; }
    string? ZipCode { get; init; }
}