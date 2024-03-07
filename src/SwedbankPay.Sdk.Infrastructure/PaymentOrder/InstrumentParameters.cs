using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder;

internal record InstrumentParameters : IInstrumentParameters
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
    
    internal InstrumentParameters(InstrumentParametersResponseDto instrumentParametersResponseDto)
    {
        AccountId = instrumentParametersResponseDto.AccountId;
        Bank = instrumentParametersResponseDto.Bank;
        ClearingHouse = instrumentParametersResponseDto.ClearingHouse;
        DirectDebitEnabled = instrumentParametersResponseDto.DirectDebitEnabled;
        FirstName = instrumentParametersResponseDto.FirstName;
        LastName = instrumentParametersResponseDto.LastName;
        ExpiryDate = instrumentParametersResponseDto.ExpiryDate;
        IssuerName = instrumentParametersResponseDto.IssuerName;
        ExpiryPan = instrumentParametersResponseDto.ExpiryPan;
        ExpiryDPan = instrumentParametersResponseDto.ExpiryDPan;
        CardBrand = instrumentParametersResponseDto.CardBrand;
        Email = instrumentParametersResponseDto.Email;
        Msisdn = instrumentParametersResponseDto.Msisdn;
        ZipCode = instrumentParametersResponseDto.ZipCode;
        LastFourPan = instrumentParametersResponseDto.LastFourPan;
        LastFourDPan = instrumentParametersResponseDto.LastFourDPan;
    }
}