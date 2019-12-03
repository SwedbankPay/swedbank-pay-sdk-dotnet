#region License

// --------------------------------------------------
// Copyright © Swedbank Pay. All Rights Reserved.
// 
// This software is proprietary information of Swedbank Pay.
// USE IS SUBJECT TO LICENSE TERMS.
// --------------------------------------------------

#endregion

namespace SwedbankPay.Sdk
{
    public sealed class LinkRelation : TypeSafeEnum<LinkRelation, string>
    {
        public static readonly LinkRelation UpdatePaymentorderUpdateorder = new LinkRelation(nameof(UpdatePaymentorderUpdateorder), "update-paymentorder-updateorder");
        public static readonly LinkRelation CreatePaymentorderCapture = new LinkRelation(nameof(CreatePaymentorderCapture), "create-paymentorder-capture");
        public static readonly LinkRelation CreatePaymentorderCancellation = new LinkRelation(nameof(CreatePaymentorderCancellation), "create-paymentorder-cancellation");
        public LinkRelation(string name, string value) : base(name, value)
        {
        }
    }
}