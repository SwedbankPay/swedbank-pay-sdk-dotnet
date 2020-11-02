using System.Collections.Generic;
using System.Linq;

namespace SwedbankPay.Sdk
{
    public class ProblemResponse
    {
        public string Action { get; set; }
        public string Detail { get; set; }
        public string Instance { get; set; }
        public List<ProblemResponseItem> Problems { get; set; }
        public int Status { get; set; }
        public string Title { get; set; }

        public string Type { get; set; }


        public override string ToString()
        {
            return Problems.Select(p => p.ToString()).Aggregate((x, y) => x + "|" + y);
        }
    }
}