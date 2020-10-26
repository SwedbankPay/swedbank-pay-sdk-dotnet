﻿using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderAuthorizationsDto
    {
        public string Id { get; set; }
        public List<TransactionDto> AuthorizationList { get; set; }

        internal IPaymentAuthorizationListResponse Map()
        {
            throw new NotImplementedException();
        }
    }
}