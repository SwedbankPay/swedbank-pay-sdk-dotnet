using System.Collections.Generic;

namespace SwedbankPay.Sdk
{
    public class OperationList : List<HttpOperation>, IOperationList
    {
        public OperationList()
        {
        }
    }
}