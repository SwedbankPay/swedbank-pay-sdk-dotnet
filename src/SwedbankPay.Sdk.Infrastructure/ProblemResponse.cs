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

        public string Action { get; }
        public string Detail { get; set; }
        public string Instance { get; set; }
        public List<IProblemResponseItem> Problems { get; }
        public int Status { get; }
        public string Title { get; }

        public string Type { get; }


        public override string ToString()
        {
            return Problems.Select(p => p.ToString()).Aggregate((x, y) => x + "|" + y);
        }
    }
}