using SwedbankPay.Sdk.Common;
using SwedbankPay.Sdk.PaymentInstruments;
using System;

namespace SwedbankPay.Sdk.PaymentOrders
{
    internal class SaleListItem : ISaleListItem
    {
        public SaleListItem(PaymentOrderTransactionDto dto)
        {
            Amount = dto.Amount;
            Created = dto.Created;
            Updated = dto.Updated;
            Type = PaymentType.FromValue(dto.Type);
            Number = dto.Number;
            State = State.FromValue(dto.State);
            VatAmount = dto.VatAmount;
            Description = dto.Description;
            PayeeReference = dto.PayeeReference;
        }

        public Uri Id { get; }
        public DateTime Created { get; }
        public DateTime Updated { get; }
        public PaymentType Type { get;  }
        public State State { get;  }
        public string Number { get; }
        public Amount Amount { get;  }
        public Amount VatAmount { get;  }
        public string Description { get;}
        public string PayeeReference { get;  }
    }
}