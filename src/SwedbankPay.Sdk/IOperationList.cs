using System.Collections.Generic;

namespace SwedbankPay.Sdk
{
    public interface IOperationList : IList<HttpOperation>
    {
        string ToString();
    }
}