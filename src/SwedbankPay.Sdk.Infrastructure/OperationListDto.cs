using SwedbankPay.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SwedbankPay.Sdk
{
    public class OperationListDto : List<HttpOperationDto>
    {
        public OperationListDto()
        {
        }

        public OperationListDto(IEnumerable<HttpOperationDto> operations)
            : base(operations)
        {
        }

        public override string ToString()
        {
            return string.Join(", ", this.Select(o => o.Rel.Value));
        }

        public IOperationList Map()
        {
            var list = new OperationList();
            foreach (var item in this)
            {
                list.Add(new HttpOperation(item.Href, item.Rel, item.Method, item.ContentType));
            }
            return list;
        }
    }
}