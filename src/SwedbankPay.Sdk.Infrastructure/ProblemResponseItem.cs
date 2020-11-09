namespace SwedbankPay.Sdk
{
    public class ProblemResponseItem : IProblemResponseItem
    {
        public string Description { get; set; }

        public string Name { get; set; }


        public override string ToString()
        {
            return $"{Name} : {Description}";
        }
    }
}