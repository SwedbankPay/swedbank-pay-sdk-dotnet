using SwedbankPay.Sdk.PaymentInstruments;
using System;

namespace SwedbankPay.Sdk
{
    public class TransactionDto
    {
        public int Amount { get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }
        public bool IsOperational { get; set; }
        public long Number { get; set; }
        public OperationListDto Operations { get; set; } = new OperationListDto();
        public string PayeeReference { get; set; }
        public string State { get; set; }
        public string Type { get; set; }
        public DateTime Updated { get; set; }
        public int VatAmount { get; set; }
        public string Activity { get; set; }

        internal ITransaction Map()
        {
            IOperationList operations = new OperationList();
            foreach (var item in Operations)
            {
                var rel = new LinkRelation(item.Rel);
                operations.Add(new HttpOperation(item.Href, rel, item.Method, item.ContentType));
            }

            var type = string.IsNullOrEmpty(Type)? TransactionType.Unknown : Enum.Parse<TransactionType>(Type);

            return new PaymentInstruments.Transaction(new Uri(Id, UriKind.RelativeOrAbsolute),
                                   Created,
                                   Updated,
                                   type,
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