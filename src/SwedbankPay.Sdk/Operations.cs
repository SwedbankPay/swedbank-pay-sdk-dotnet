namespace SwedbankPay.Sdk
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    public class Operations : List<HttpOperation>
    {
        public Operations()
        {

        }

        public Operations(IEnumerable<HttpOperation> operations) : base(operations)
        {
            
        }
        
        public override string ToString()
        {
            return this.Select(o => o.Rel).Aggregate((x, y) => x + "," + y);
        }
    }
}