namespace SwedbankPay.Sdk.Extensions;

public interface ISwedbankPayClientFactory
{
    ISwedbankPayClient CreateClient(string authenticationToken);
}