using System.Collections.Generic;

namespace SwedbankPay.Sdk
{
    internal class ProblemResponseDto
    {
        public string Action { get; set; }
        public string Detail { get; set; }
        public string Instance { get; set; }
        public List<ProblemResponseItemDto> Problems { get; set; } = new List<ProblemResponseItemDto>();
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