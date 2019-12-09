namespace SwedbankPay.Sdk.Consumers
{
    using System.Collections.Generic;

    public class Operations : Dictionary<LinkRelation, HttpOperation>
    {
        public HttpOperation ViewConsumerIdentification { get; internal set; }
        public HttpOperation RedirectConsumerIdentification { get; internal set; }
        public HttpOperation this[LinkRelation rel] => ContainsKey(rel) ? base[rel] : null;
    }
}
