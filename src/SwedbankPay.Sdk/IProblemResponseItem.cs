namespace SwedbankPay.Sdk
{
    public interface IProblemResponseItem
    {
        string Description { get; }
        string Name { get; }
        string ToString();
    }
}