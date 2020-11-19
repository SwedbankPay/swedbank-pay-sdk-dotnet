using SwedbankPay.Sdk.Extensions;
using System.Collections.Generic;

namespace SwedbankPay.Sdk
{
    public class ProblemResponseDto
    {
        public string Action { get; set; }
        public string Detail { get; set; }
        public string Instance { get; set; }
        public List<ProblemResponseItemDto> Problems { get; set; } = new List<ProblemResponseItemDto>();
        public int Status { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }

        internal IProblemResponse Map()
        {
            var list = new List<IProblemResponseItem>();
            foreach (var item in Problems)
            {
                list.Add(item.Map());
            }
            return new ProblemResponse(Action, Detail, Instance, list, Status, Title, Type);
        }
    }
}