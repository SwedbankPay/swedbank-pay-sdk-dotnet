using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder;

internal record UserTokenResponse : IUserTokenResponse
{
    public UserTokenResponse(UserTokenResponseDto userTokenResponseDto, HttpClient httpClient)
    {
        Id = userTokenResponseDto.PayerOwnedTokens.Id;
        PayerReference = userTokenResponseDto.PayerOwnedTokens?.PayerReference;
        
        if (userTokenResponseDto.PayerOwnedTokens?.Tokens != null)
        {
            Tokens = userTokenResponseDto.PayerOwnedTokens.Tokens?.Select(x => x.Map(httpClient)).ToList();
        }

        if (userTokenResponseDto.Operations != null)
        {        
            Operations = new UserTokenOperations(userTokenResponseDto.Operations.Map(), httpClient);
        }
    }

    public UserTokenResponse(UserTokenResponseItemDto userTokenResponseItemDto, HttpClient httpClient)
    {
        Tokens = new List<IUserToken> { userTokenResponseItemDto.Map(httpClient) };
    }
    
    public string? Id { get; }
    public string? PayerReference { get; }
    public List<IUserToken>? Tokens { get; }
    public IUserTokenOperations? Operations { get;}

}