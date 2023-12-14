namespace SwedbankPay.Sdk.PaymentOrder.Models;

public class TokenItem
{
    public string? Type { get; }
    public string? Token { get; }
    public string? Name { get; }
    public string? ExpiryDate { get; }

    internal TokenItem(TokenItemDto dto)
    {
        Type = dto.Type;
        Token = dto.Token;
        Name = dto.Name;
        ExpiryDate = dto.ExpiryDate;
    }
}