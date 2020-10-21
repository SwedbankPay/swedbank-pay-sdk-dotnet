using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class AuthorizationTransactionResponseDto
    {
        public string Payment { get; set; }
        public List<PaymentOrderTransactionDto> Authorizaiton { get; set; }

        internal IPaymentAuthorizationListResponse Map()
        {
            throw new NotImplementedException();
        }
    }

}