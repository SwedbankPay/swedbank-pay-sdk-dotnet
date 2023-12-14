namespace SwedbankPay.Sdk.PaymentOrder.Models;

internal record FailedAttemptListItemDto
{
    public DateTime Created { get; set; }
    public string? Instrument { get; set; }
    public long Number { get; set; }
    public string? Status { get; set; }
    public ProblemDto? Problem { get; set; }

    public FailedAttemptListItem Map()
    {
        return new FailedAttemptListItem(this);
    }
}