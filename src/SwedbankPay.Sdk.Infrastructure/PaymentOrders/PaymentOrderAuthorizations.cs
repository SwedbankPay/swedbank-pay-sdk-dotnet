using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderAuthorizations
    {
        public string Id { get; set; }
        public List<PaymentOrderTransactionListDto> AuthorizationList { get; set; }
    }
}