using System.Collections.Generic;

namespace SwedbankPay.Sdk
{
    internal class ProblemDto
    {
        public string Action { get; set; }
        public string Detail { get; set; }
        public string Instance { get; set; }
        public List<ProblemtemDto> Problems { get; set; } = new List<ProblemtemDto>();
        public int Status { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }

        internal IProblem Map()
        {
            var response = new Problem(Action, Detail, Instance, Status, Title, Type);
            foreach (var item in Problems)
            {
                response.Problems.Add(item.Map());
            }

            return response;
        }
    }
}