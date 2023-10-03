using System.Text.Json;

namespace SwedbankPay.Sdk;

public class Problem : IProblem
{
    public string? Type { get; }
    public string? Title { get; }
    public string? Detail { get; }
    public string? Instance { get; }
    public int Status { get; }
    public string? Action { get; }
    public IList<IProblemItem>? Problems { get; }
    
    
    internal Problem(ProblemDto dto)
    {
        
        Type = dto.Type;
        Title = dto.Title;
        Detail = dto.Detail;
        Instance = dto.Instance;
        Status = dto.Status;
        Action = dto.Action;
        Problems = dto.Problems?.Select(x => x.Map()).ToList();
    }

    public Problem(string? detail, int status, string? title, string? type)
    {
        Type = type;
        Title = title;
        Detail = detail;
        Status = status;
    }

    public override string ToString()
    {
        var problems = JsonSerializer.Serialize(Problems, JsonSerialization.JsonSerialization.Settings);
        return problems;
    }
}