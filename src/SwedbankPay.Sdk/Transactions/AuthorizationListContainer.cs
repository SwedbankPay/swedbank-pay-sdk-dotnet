namespace SwedbankPay.Sdk.Transactions
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class AuthorizationListContainer : IdLink
    {
        public List<TransactionContainerResponse> AuthorizationList { get; }


        public AuthorizationListContainer()
        {
            AuthorizationList = new List<TransactionContainerResponse>();;
        }

        [JsonConstructor]
        public AuthorizationListContainer(List<TransactionContainerResponse> authorizationList)
        {
            AuthorizationList = authorizationList;
        }
    }
}