using System.Collections.Generic;

namespace SwedbankPay.Sdk.Consumers
{
    public class Operations : Dictionary<LinkRelation, HttpOperation>
    {
        public HttpOperation this[LinkRelation rel] => ContainsKey(rel) ? base[rel] : null;
        public HttpOperation RedirectConsumerIdentification { get; internal set; }
        public HttpOperation ViewConsumerIdentification { get; internal set; }
    }
}