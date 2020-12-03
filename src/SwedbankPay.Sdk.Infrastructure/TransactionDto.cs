using SwedbankPay.Sdk.PaymentInstruments;
using System;

namespace SwedbankPay.Sdk
{
    internal class TransactionDto
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
        public ProblemResponse Problem { get; set; }

        internal ITransaction Map()
        {
            IOperationList operations = new OperationList();
            foreach (var item in Operations)
            {
                var rel = new LinkRelation(item.Rel);
                operations.Add(new HttpOperation(item.Href, rel, item.Method, item.ContentType));
            }

            var type = string.IsNullOrEmpty(Type)? TransactionType.Unknown : Enum.Parse<TransactionType>(Type);
            var state = string.IsNullOrEmpty(State) ? "Unknown" : State;
            var id = new Uri(Id, UriKind.RelativeOrAbsolute);

            return new Transaction(id,
                                   Created,
                                   Updated,
                                   type,
                                   state,
                                   Number,
                                   Amount,
                                   VatAmount,
                                   Description,
                                   PayeeReference,
                                   IsOperational,
                                   operations,
                                   Activity,
                                   Problem);
        }
    }
}