#region License

// --------------------------------------------------
// Copyright © Swedbank Pay. All Rights Reserved.
// 
// This software is proprietary information of Swedbank Pay.
// USE IS SUBJECT TO LICENSE TERMS.
// --------------------------------------------------

#endregion

using System.Collections.Generic;

using SwedbankPay.Sdk.Transactions;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class Operations : Dictionary<LinkRelation, HttpOperation>
    {
        public ExecuteRequestWrapper<TransactionRequestContainer, CancellationTransactionResponseContainer> Cancel { get; internal set; }
        public ExecuteRequestWrapper<TransactionRequestContainer, CaptureTransactionResponseContainer> Capture { get; internal set; }

        public ExecuteRequestWrapper<PaymentOrderUpdateRequestContainer, PaymentOrderResponseContainer> Update { get; internal set; }
        public ExecuteRequestWrapper<TransactionRequestContainer, ReversalTransactionResponseContainer> Reversal { get; internal set; }
        public ExecuteWrapper<PaymentOrderResponseContainer> Abort { get; internal set; }
        public HttpOperation View { get; internal set; }
        public HttpOperation this[LinkRelation rel] => ContainsKey(rel) ? base[rel] : null;
    }
}