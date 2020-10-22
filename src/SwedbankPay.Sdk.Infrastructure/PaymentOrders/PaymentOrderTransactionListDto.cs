using SwedbankPay.Sdk.Common;
using SwedbankPay.Sdk.PaymentInstruments;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderTransactionListDto
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Type { get; set; }
        public string State { get; set; }
        public string Number { get; set; }
        public int Amount { get; set; }
        public int VatAmount { get; set; }
        public string Description { get; set; }
        public string PayeeReference { get; set; }
        public bool IsOperational { get; set; }
        public List<HttpOperationDto> Operations { get; set; }
        public string Activity { get; set; }

        internal ITransaction Map()
        {
            IOperationList operations = new OperationList();
            foreach (var item in Operations)
            {
                var rel = new LinkRelation(item.Rel);
                operations.Add(new HttpOperation(item.Href, rel, item.Method, item.ContentType));
            }

            return new Transaction(new Uri(Id, UriKind.RelativeOrAbsolute),
                                   Created,
                                   Updated,
                                   Enum.Parse<TransactionType>(Type),
                                   State,
                                   Number,
                                   Amount,
                                   VatAmount,
                                   Description,
                                   PayeeReference,
                                   IsOperational,
                                   operations,
                                   Activity);
        }
    }
}