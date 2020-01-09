using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Transactions
{
    public class AuthorizationListContainer : IdLink
    {
        public AuthorizationListContainer(Uri id, List<TransactionContainerResponse> authorizationList)
        {
            Id = id;
            AuthorizationList = authorizationList;
        }
        
        public List<TransactionContainerResponse> AuthorizationList { get; }
    }
}