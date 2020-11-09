namespace SwedbankPay.Sdk
{
    public interface IProblemResponseItem
    {
        string Description { get; set; }
        string Name { get; set; }

        string ToString();
    }
}