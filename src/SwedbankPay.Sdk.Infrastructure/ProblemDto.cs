namespace SwedbankPay.Sdk.Infrastructure;

internal record ProblemDto
{
    public string? Type { get; set; }
    public string? Title { get; set; }
    public string? Detail { get; set; }
    public string? Instance { get; set; }
    public int Status { get; set; }
    public string? Action { get; set; }
    public List<ProblemItemDto>? Problems { get; set; }

    internal IProblem Map()
    {
        return new Problem(this);
    }
}