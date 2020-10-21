using SwedbankPay.Sdk.Common;
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
            return string.Join(", ", this.Select(o => o.Rel));
        }

        public IOperationList Map()
        {
            var list = new OperationList();
            foreach (var item in this)
            {
                var rel = new LinkRelation(item.Rel);
                list.Add(new HttpOperation(item.Href, rel, item.Method, item.ContentType));
            }
            return list;
        }
    }
}