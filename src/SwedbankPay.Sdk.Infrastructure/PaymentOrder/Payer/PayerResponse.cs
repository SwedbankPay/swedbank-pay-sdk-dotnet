using SwedbankPay.Sdk.PaymentOrder.Payer;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.Payer;

internal record PayerResponse : Identifiable, IPayerResponse
{
    public IDevice? Device { get; }
    public string? Reference { get; }
    public string? Name { get; }
    public EmailAddress? Email { get; }
    public Msisdn? Msisdn { get; }
    public Dictionary<string, string>? HashedFields { get; }
    
    internal PayerResponse(PayerResponseDto dto) : base(dto.Id)
    {
        Device = dto.Device?.Map();
        Reference = dto.Reference;
        Name = dto.Name;
        HashedFields = dto.HashedFields;

        if (!string.IsNullOrWhiteSpace(dto.Email))
        {
            Email = new EmailAddress(dto.Email!);
        }
        
        if (!string.IsNullOrWhiteSpace(dto.Msisdn))
        {
            Msisdn = new Msisdn(dto.Msisdn!);
        }
    }
}