namespace SwedbankPay.Sdk.Infrastructure;

internal record ProblemItem : IProblemItem
{
    public ProblemItem(ProblemItemDto dto)
    {
        Description = dto.Description;
        Name = dto.Name;
    }

    public string? Description { get; }

    public string? Name { get; }
}