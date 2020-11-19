using System.Collections.Generic;
using System.Linq;

namespace SwedbankPay.Sdk
{
    public class ProblemResponse : IProblemResponse
    {
        public ProblemResponse()
        {
        }

        public ProblemResponse(string action, string detail, string instance, List<IProblemResponseItem> list, int status, string title, string type)
        {
            Action = action;
            Detail = detail;
            Instance = instance;
            Problems = list;
            Status = status;
            Title = title;
            Type = type;
        }

        public string Action { get; set; }
        public string Detail { get; set; }
        public string Instance { get; set; }
        public List<IProblemResponseItem> Problems { get; set;}
        public int Status { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return Problems.Select(p => p.ToString()).Aggregate((x, y) => x + "|" + y);
        }
    }
}