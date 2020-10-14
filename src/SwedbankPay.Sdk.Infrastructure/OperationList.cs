using System.Collections.Generic;
using System.Linq;

namespace SwedbankPay.Sdk
{
    public class OperationList : IOperationList
    {
        public OperationList(IEnumerable<HttpOperation> operations)
            : base(operations)
        {
        }


        public override string ToString()
        {
            return string.Join(", ", this.Select(o => o.Rel.Value));
        }
    }
}