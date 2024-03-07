namespace SwedbankPay.Sdk.PaymentOrder;

public interface IUserTokenResponse
{
   string? Id { get; }
   string? PayerReference { get; }
   List<IUserToken>? Tokens { get; }
   
   IUserTokenOperations? Operations { get;}
}