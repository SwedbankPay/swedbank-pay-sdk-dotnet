#region License

// --------------------------------------------------
// Copyright © Swedbank Pay. All Rights Reserved.
// 
// This software is proprietary information of Swedbank Pay.
// USE IS SUBJECT TO LICENSE TERMS.
// --------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using SwedbankPay.Sdk.Payments;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderOperations : Dictionary<LinkRelation, HttpOperation>
    {
        public new HttpOperation this[LinkRelation rel] => ContainsKey(rel) ? base[rel] : null;
        public Func<Task<PaymentOrderResponse>> Abort { get; internal set; }
        public Func<PaymentOrderCancelRequest, Task<CancellationResponse>> Cancel { get; internal set; }
        public Func<PaymentOrderCaptureRequest, Task<CaptureResponse>> Capture { get; internal set; }
        public Func<PaymentOrderReversalRequest, Task<ReversalResponse>> Reverse { get; internal set; }
        public Func<PaymentOrderUpdateRequest, Task<PaymentOrderResponse>> Update { get; internal set; }
        public HttpOperation View { get; internal set; }
    }
}