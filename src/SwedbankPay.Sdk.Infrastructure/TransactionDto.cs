using SwedbankPay.Sdk.Common;
using SwedbankPay.Sdk.PaymentInstruments;
using System;

namespace SwedbankPay.Sdk
{
    public class TransactionDto
    {
        public int Amount { get; }
        public DateTime Created { get; }
        public string Description { get; }
        public string Id { get; }
        public bool IsOperational { get; }
        public string Number { get; }
        public OperationListDto Operations { get; }
        public string PayeeReference { get; }
        public string State { get; }
        public string Type { get; }
        public DateTime Updated { get; }
        public int VatAmount { get; }
        public string Activity { get; }

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