using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments
{
    public class PaymentOperationsDto
    {
        public List<HttpOperation> Operations { get; set; }

        public IOperationList Map()
        {
            return new OperationList(Operations);
        }
    }
}