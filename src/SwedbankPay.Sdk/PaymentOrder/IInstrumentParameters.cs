namespace SwedbankPay.Sdk.PaymentOrder;

public interface IInstrumentParameters
{
    string? AccountId { get; init; }
    string? Bank { get; init; }
    string? ClearingHouse { get; init; }
    bool DirectDebitEnabled { get; init; }
    string? FirstName { get; init; }
    string? LastName { get; init; }
    string? ExpiryDate { get; init; }
    string? IssuerName { get; init; }
    DateTime? ExpiryPan { get; init; }
    DateTime? ExpiryDPan { get; init; }
    string? CardBrand { get; init; }
    string? Email { get; init; }
    string? Msisdn { get; init; }
    string? ZipCode { get; init; }
    string? LastFourPan { get; init; }
    string? LastFourDPan { get; init; }
}