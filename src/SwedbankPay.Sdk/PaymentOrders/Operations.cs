#region License

// --------------------------------------------------
// Copyright © Swedbank Pay. All Rights Reserved.
// 
// This software is proprietary information of Swedbank Pay.
// USE IS SUBJECT TO LICENSE TERMS.
// --------------------------------------------------

#endregion

using SwedbankPay.Sdk.PaymentOrders.OperationRequests;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using SwedbankPay.Sdk.Payments;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class Operations : Dictionary<LinkRelation, HttpOperation>
    {
        public HttpOperation this[LinkRelation rel] => ContainsKey(rel) ? base[rel] : null;
        public Func<Task<PaymentOrderResponse>> Abort { get; internal set; }
        public Func<CancelRequest, Task<CancellationResponse>> Cancel { get; internal set; }
        public Func<CaptureRequest, Task<CaptureResponse>> Capture { get; internal set; }
        public Func<ReversalRequest, Task<ReversalResponse>> Reversal { get; internal set; }
        public Func<UpdateRequest, Task<PaymentOrderResponse>> Update { get; internal set; }
        public HttpOperation View { get; internal set; }
    }
}