namespace SwedbankPay.Sdk.PaymentOrder.OperationRequest.RemoveToken;

public sealed class TokenState : TypeSafeEnum<TokenState>
{
    public static readonly TokenState Deleted = new TokenState(nameof(Deleted), "Deleted");

    public TokenState(string name, string value) : base(name, value)
    {
    }
}