using System.Collections.Generic;
using System.Text.Json;

namespace SwedbankPay.Sdk
{
    internal class Problem : IProblem
    {
        public Problem(string action, string detail, string instance, int status, string title, string type)
        {
            Action = action;
            Detail = detail;
            Instance = instance;
            Status = status;
            Title = title;
            Type = type;
        }

        public string Action { get;}
        public string Detail { get; }
        public string Instance { get; }
        public IList<IProblemItem> Problems { get; } = new List<IProblemItem>();
        public int Status { get; }
        public string Title { get; }
        public string Type { get; }

        public override string ToString()
        {
            var problems = JsonSerializer.Serialize(Problems, JsonSerialization.JsonSerialization.Settings);
            return problems;
        }
    }
}