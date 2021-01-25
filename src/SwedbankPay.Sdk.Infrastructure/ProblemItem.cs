namespace SwedbankPay.Sdk
{
    internal class ProblemItem : IProblemItem
    {
        public ProblemItem(ProblemItemDto dto)
        {
            Description = dto.Description;
            Name = dto.Name;
        }

        public ProblemItem(string description, string name)
        {
            Description = description;
            Name = name;
        }

        public string Description { get; }

        public string Name { get; }
    }
}