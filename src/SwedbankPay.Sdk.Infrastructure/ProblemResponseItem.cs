namespace SwedbankPay.Sdk
{
    internal class ProblemResponseItem : IProblemResponseItem
    {
        public ProblemResponseItem(string description, string name)
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