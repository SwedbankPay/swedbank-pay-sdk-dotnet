namespace SwedbankPay.Sdk.Infrastructure;

internal record ProblemDto
{
    public string? Type { get; init; }
    public string? Title { get; init; }
    public string? Detail { get; init; }
    public string? Instance { get; init; }
    public int Status { get; init; }
    public string? Action { get; init; }
    public List<ProblemItemDto>? Problems { get; init; }

    internal IProblem Map()
    {
        return new Problem(this);
    }
}