using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SwedbankPay.Sdk.Consumers
{
    [Serializable]
    public class Operations : Dictionary<LinkRelation, HttpOperation>
    {
        public Operations() 
        { 
        }

        protected Operations(
           SerializationInfo info,
           StreamingContext context) : base(info, context)
        {
            RedirectConsumerIdentification = (HttpOperation)info.GetValue("RedirectConsumerIdentification", typeof(HttpOperation));
            RedirectConsumerIdentification = (HttpOperation)info.GetValue("ViewConsumerIdentification", typeof(HttpOperation));
        }

        public HttpOperation this[LinkRelation rel] => ContainsKey(rel) ? base[rel] : null;
        public HttpOperation RedirectConsumerIdentification { get; internal set; }
        public HttpOperation ViewConsumerIdentification { get; internal set; }
    }
}