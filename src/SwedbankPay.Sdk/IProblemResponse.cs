using System.Collections.Generic;

namespace SwedbankPay.Sdk
{
    public interface IProblemResponse
    {
        string Action { get; }
        string Detail { get; }
        string Instance { get; }
        List<IProblemResponseItem> Problems { get; }
        int Status { get; }
        string Title { get; }
        string Type { get; }

        string ToString();
    }
}