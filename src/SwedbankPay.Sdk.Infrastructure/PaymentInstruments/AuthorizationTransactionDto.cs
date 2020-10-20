using SwedbankPay.Sdk.PaymentInstruments.Card;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class AuthorizationTransactionDto : List<TransactionDto>
    {
        internal ICardPaymentAuthorizationListResponse Map() => throw new NotImplementedException();
    }
}