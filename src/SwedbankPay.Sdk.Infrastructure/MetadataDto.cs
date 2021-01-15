using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk
{
    internal class MetadataDto : Dictionary<string, object>
    {
        public string Id { get; set; }

        internal Metadata Map()
        {
            var metaData = new Metadata(this);
            return metaData;
        }
    }
}
