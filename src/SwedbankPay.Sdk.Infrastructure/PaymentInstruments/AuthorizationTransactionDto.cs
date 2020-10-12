using SwedbankPay.Sdk.Payments.CardPayments;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments
{
    public class AuthorizationTransactionDto : List<TransactionDto>
    {
        internal ICardPaymentAuthorizationListResponse Map() => throw new NotImplementedException();
    }
}