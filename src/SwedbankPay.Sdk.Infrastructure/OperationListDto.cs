using SwedbankPay.Sdk.Common;
using System.Collections.Generic;
using System.Linq;

namespace SwedbankPay.Sdk
{
    public class OperationListDto : List<HttpOperation>, IOperationList
    {
        public OperationListDto()
        {
        }

        public OperationListDto(IEnumerable<HttpOperation> operations)
            : base(operations)
        {
        }

        public override string ToString()
        {
            return string.Join(", ", this.Select(o => o.Rel.Value));
        }
    }
}