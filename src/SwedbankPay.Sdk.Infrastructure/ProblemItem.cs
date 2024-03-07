namespace SwedbankPay.Sdk.Infrastructure;

internal record ProblemItem : IProblemItem
{
    internal ProblemItem(ProblemItemDto dto)
    {
        Description = dto.Description;
        Name = dto.Name;
    }

    public string? Description { get; }

    public string? Name { get; }
}