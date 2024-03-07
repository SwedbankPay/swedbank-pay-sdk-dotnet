namespace SwedbankPay.Sdk.Infrastructure;

internal record ProblemItemDto
{
    public string? Description { get; init; }

    public string? Name { get; init; }

    internal IProblemItem Map()
    {
        return new ProblemItem(this);
    }
}