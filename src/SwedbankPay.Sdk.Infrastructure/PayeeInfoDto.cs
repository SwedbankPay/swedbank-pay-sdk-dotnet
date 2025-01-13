namespace SwedbankPay.Sdk.Infrastructure;

internal record PayeeInfoDto
{
    public PayeeInfoDto(PayeeInfo payeeInfo)
    {
        PayeeId = payeeInfo.PayeeId;
        PayeeReference = payeeInfo.PayeeReference;
        PayeeName = payeeInfo.PayeeName;
        ProductCategory = payeeInfo.ProductCategory;
        OrderReference = payeeInfo.OrderReference;
        Subsite = payeeInfo.Subsite;
        SiteId = payeeInfo.SiteId;
    }

    public string? PayeeId { get; init; }
    public string PayeeReference { get; init; }
    public string? PayeeName { get; init; }
    public string? ProductCategory { get; init; }
    public string? OrderReference { get; init; }
    public string? Subsite { get; init; }
    public string? SiteId { get; init; }
}