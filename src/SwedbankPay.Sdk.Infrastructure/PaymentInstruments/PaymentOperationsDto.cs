using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments
{
    public class PaymentOperationsDto
    {
        public List<HttpOperationDto> Operations { get; set; }

        public IOperationList Map()
        {
            var list = new List<HttpOperation>();
            foreach (var item in Operations)
            {
                list.Add(new HttpOperation(item.Href, item.Rel, item.Method, item.ContentType));
            }
            return new OperationList(list);
        }
    }
}