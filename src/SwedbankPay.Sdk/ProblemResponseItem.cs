namespace SwedbankPay.Sdk.Common
{
    public class ProblemResponseItem
    {
        public ProblemResponseItem(string name, string description)
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