namespace SwedbankPay.Sdk.PaymentInstruments.Vipps;

internal class VippsAuthorizationTransactionDto
{
    public VippsAuthorizationTransactionDto(VippsAuthorizationTransaction transaction)
    {
        Msisdn = transaction.Msisdn;
    }

    public string Msisdn { get; }
}