using System;

namespace SwedbankPay.Sdk.Extensions
{
    public class ProblemResponseItemDto
    {
        public string Description { get; set; }

        public string Name { get; set; }

        internal IProblemResponseItem Map()
        {
            return new ProblemResponseItem(Description, Name);
        }
    }
}