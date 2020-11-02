using System.Collections.Generic;

namespace SwedbankPay.Sdk.Common
{
    public interface IOperationList : IList<HttpOperation>
    {
        string ToString();
    }
}