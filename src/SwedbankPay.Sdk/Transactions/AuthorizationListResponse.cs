using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Transactions
{
    public class AuthorizationListResponse : IdLink
    {
        public AuthorizationListResponse(Uri id, List<TransactionResponse> authorizationList)
        {
            Id = id;
            AuthorizationList = authorizationList;
        }
        
        public List<TransactionResponse> AuthorizationList { get; }
    }
}