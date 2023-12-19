namespace SwedbankPay.Sdk.Infrastructure;

internal record ProblemItemDto
{
    public string? Description { get; set; }

    public string? Name { get; set; }

    internal IProblemItem Map()
    {
        return new ProblemItem(this);
    }
}