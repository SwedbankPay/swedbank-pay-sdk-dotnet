using System.Text;

namespace SwedbankPay.Sdk
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    public class OperationList : List<HttpOperation>
    {
        public OperationList()
        {

        }

        public OperationList(IEnumerable<HttpOperation> operations) : base(operations)
        {
            
        }
        
        public override string ToString()
        {
            return string.Join(", ", this.Select(o => o.Rel.Value));
        }
    }
}