namespace SwedbankPay.Sdk
{
    internal class ProblemResponseItemDto
    {
        public string Description { get; set; }

        public string Name { get; set; }

        internal IProblemItem Map()
        {
            return new ProblemItem(Description, Name);
        }
    }
}