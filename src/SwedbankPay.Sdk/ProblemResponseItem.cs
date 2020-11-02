namespace SwedbankPay.Sdk
{
    public class ProblemResponseItem
    {
        public string Description { get; set; }

        public string Name { get; set; }


        public override string ToString()
        {
            return $"{Name} : {Description}";
        }
    }
}