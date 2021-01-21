namespace SwedbankPay.Sdk
{
    internal class ProblemItem : IProblemItem
    {
        public ProblemItem(string description, string name)
        {
            Description = description;
            Name = name;
        }

        public string Description { get; }

        public string Name { get; }


        public override string ToString()
        {
            return $"{Name} : {Description}";
        }
    }
}