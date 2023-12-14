namespace SwedbankPay.Sdk.PaymentOrder.Models;

public class FailedAttemptListItem
{
    public DateTime Created { get; set; }
    public string? Instrument { get; set; }
    public long Number { get; set; }
    public string? Status { get; set; }
    public Problem? Problem { get; set; }

    internal FailedAttemptListItem(FailedAttemptListItemDto dto)
    {
        Created = dto.Created;
        Instrument = dto.Instrument;
        Number = dto.Number;
        Status = dto.Status;
        Problem = dto.Problem?.Map();
    }
}