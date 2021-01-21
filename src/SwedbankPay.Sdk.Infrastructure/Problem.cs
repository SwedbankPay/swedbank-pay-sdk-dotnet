using System.Collections.Generic;
using System.Linq;
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

        public string Action { get; set; }
        public string Detail { get; set; }
        public string Instance { get; set; }
        public IList<IProblemItem> Problems { get; } = new List<IProblemItem>();
        public int Status { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            var problems = JsonSerializer.Serialize(Problems, JsonSerialization.JsonSerialization.Settings);
            return problems;
        }
    }
}