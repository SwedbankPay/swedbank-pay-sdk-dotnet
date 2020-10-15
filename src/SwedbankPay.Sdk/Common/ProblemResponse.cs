using System.Collections.Generic;
using System.Linq;

namespace SwedbankPay.Sdk
{
    public class ProblemResponse
    {
        public ProblemResponse()
        {

        }


        public ProblemResponse(string type,
                               string title,
                               string detail,
                               string instance,
                               int status,
                               string action,
                               IEnumerable<ProblemResponseItem> problems)
        {
            Type = type;
            Title = title;
            Detail = detail;
            Instance = instance;
            Status = status;
            Action = action;
            Problems = problems;
        }


        public string Action { get; }
        public string Detail { get; }
        public string Instance { get; }
        public IEnumerable<ProblemResponseItem> Problems { get; }
        public int Status { get; }
        public string Title { get; }

        public string Type { get; }


        public override string ToString()
        {
            return Problems.Select(p => p.ToString()).Aggregate((x, y) => x + "|" + y);
        }
    }
}