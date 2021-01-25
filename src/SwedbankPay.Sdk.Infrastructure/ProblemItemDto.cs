namespace SwedbankPay.Sdk
{
    internal class ProblemItemDto
    {
        public string Description { get; set; }

        public string Name { get; set; }

        internal IProblemResponseItem Map()
        {
            return new ProblemResponseItem(Description, Name);
        }
    }
}