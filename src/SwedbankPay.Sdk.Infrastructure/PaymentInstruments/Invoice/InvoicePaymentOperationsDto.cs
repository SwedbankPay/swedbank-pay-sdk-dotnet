using SwedbankPay.Sdk;
using System.Collections.Generic;

namespace Swedbankpay.Sdk.Payments
{
    public class InvoicePaymentOperationsDto
    {
        public List<HttpOperation> Operations { get; set; }

        public IOperationList Map()
        {
            return new OperationList(Operations);
        }
    }
}