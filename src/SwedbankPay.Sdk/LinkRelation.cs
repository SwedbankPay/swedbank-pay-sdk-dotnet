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
        public static readonly LinkRelation UpdatePaymentorderUpdateorder = new LinkRelation(nameof(UpdatePaymentorderUpdateorder), PaymentOrderResourceOperations.UpdatePaymentOrderUpdateOrder);
        public static readonly LinkRelation CreatePaymentorderCapture = new LinkRelation(nameof(CreatePaymentorderCapture), PaymentOrderResourceOperations.CreatePaymentOrderCapture);
        public static readonly LinkRelation CreatePaymentorderCancel = new LinkRelation(nameof(CreatePaymentorderCancel), PaymentOrderResourceOperations.CreatePaymentOrderCancel); 
        public static readonly LinkRelation UpdateAbort = new LinkRelation(nameof(UpdateAbort),  PaymentOrderResourceOperations.UpdatePaymentOrderAbort);
        public static readonly LinkRelation CreatePaymentOrderReversal = new LinkRelation(nameof(CreatePaymentOrderReversal), PaymentOrderResourceOperations.CreatePaymentOrderReversal);
        public static readonly LinkRelation View = new LinkRelation(nameof(View), PaymentOrderResourceOperations.ViewPaymentOrder);
        public static readonly LinkRelation RedirectPaymentorder = new LinkRelation(nameof(RedirectPaymentorder), PaymentOrderResourceOperations.RedirectPaymentOrder);
        public static readonly LinkRelation RedirectVerification = new LinkRelation(nameof(RedirectVerification), PaymentOrderResourceOperations.RedirectVerification);
        public static readonly LinkRelation ViewConsumerIdentification = new LinkRelation(nameof(ViewConsumerIdentification), ConsumerResourceOperations.ViewConsumerIdentification);
        public static readonly LinkRelation RedirectConsumerIdentification = new LinkRelation(nameof(RedirectConsumerIdentification), ConsumerResourceOperations.RedirectConsumerIdentification);
        public static readonly LinkRelation CreateCancellation = new LinkRelation(nameof(CreateCancellation), PaymentResourceOperations.CreateCancellation);
        public static readonly LinkRelation CreateCapture = new LinkRelation(nameof(CreateCapture), PaymentResourceOperations.CreateCapture);
        public static readonly LinkRelation CreateReversal = new LinkRelation(nameof(CreateReversal), PaymentResourceOperations.CreateReversal);
        public static readonly LinkRelation PaidPaymentOrder = new LinkRelation(nameof(PaidPaymentOrder), PaymentOrderResourceOperations.PaidPaymentOrder);
        public static readonly LinkRelation PaidPayment = new LinkRelation(nameof(PaidPayment), PaymentResourceOperations.PaidPayment);

        public LinkRelation(string name, string value) : base(name, value)
        {
        }
    }
}