namespace SwedbankPay.Sdk.Extensions
{
    internal class ProblemResponseItemDto
    {
        public string Description { get; set; }

        public string Name { get; set; }

        internal IProblemResponseItem Map()
        {
            return new ProblemResponseItem(Description, Name);
        }
    }
}