#region License

// --------------------------------------------------
// Copyright © Swedbank Pay. All Rights Reserved.
// 
// This software is proprietary information of Swedbank Pay.
// USE IS SUBJECT TO LICENSE TERMS.
// --------------------------------------------------

#endregion

using SwedbankPay.Sdk.Consumers;

namespace SwedbankPay.Sdk
{
    public sealed class LinkRelation : TypeSafeEnum<LinkRelation, string>
    {
        public static readonly LinkRelation UpdatePaymentOrderUpdateOrder =
            new LinkRelation(nameof(UpdatePaymentOrderUpdateOrder), PaymentOrderResourceOperations.UpdatePaymentOrderUpdateOrder);

        public static readonly LinkRelation CreatePaymentOrderCapture =
            new LinkRelation(nameof(CreatePaymentOrderCapture), PaymentOrderResourceOperations.CreatePaymentOrderCapture);

        public static readonly LinkRelation CreatePaymentOrderCancel =
            new LinkRelation(nameof(CreatePaymentOrderCancel), PaymentOrderResourceOperations.CreatePaymentOrderCancel);

        public static readonly LinkRelation UpdateAbort =
            new LinkRelation(nameof(UpdateAbort), PaymentOrderResourceOperations.UpdatePaymentOrderAbort);

        public static readonly LinkRelation CreatePaymentOrderReversal =
            new LinkRelation(nameof(CreatePaymentOrderReversal), PaymentOrderResourceOperations.CreatePaymentOrderReversal);

        public static readonly LinkRelation View = new LinkRelation(nameof(View), PaymentOrderResourceOperations.ViewPaymentOrder);

        public static readonly LinkRelation RedirectPaymentOrder =
            new LinkRelation(nameof(RedirectPaymentOrder), PaymentOrderResourceOperations.RedirectPaymentOrder);

        public static readonly LinkRelation RedirectVerification =
            new LinkRelation(nameof(RedirectVerification), PaymentOrderResourceOperations.RedirectVerification);

        public static readonly LinkRelation ViewConsumerIdentification =
            new LinkRelation(nameof(ViewConsumerIdentification), ConsumerResourceOperations.ViewConsumerIdentification);

        public static readonly LinkRelation RedirectConsumerIdentification =
            new LinkRelation(nameof(RedirectConsumerIdentification), ConsumerResourceOperations.RedirectConsumerIdentification);

        public static readonly LinkRelation CreateCancellation =
            new LinkRelation(nameof(CreateCancellation), PaymentResourceOperations.CreateCancellation);

        public static readonly LinkRelation
            CreateCapture = new LinkRelation(nameof(CreateCapture), PaymentResourceOperations.CreateCapture);

        public static readonly LinkRelation CreateReversal =
            new LinkRelation(nameof(CreateReversal), PaymentResourceOperations.CreateReversal);

        public static readonly LinkRelation PaidPaymentOrder =
            new LinkRelation(nameof(PaidPaymentOrder), PaymentOrderResourceOperations.PaidPaymentOrder);

        public static readonly LinkRelation PaidPayment = new LinkRelation(nameof(PaidPayment), PaymentResourceOperations.PaidPayment);

        public static readonly LinkRelation UpdatePaymentAbort =
            new LinkRelation(nameof(UpdatePaymentAbort), PaymentResourceOperations.UpdatePaymentAbort);

        public static readonly LinkRelation ViewAuthorization =
            new LinkRelation(nameof(ViewAuthorization), PaymentResourceOperations.ViewAuthorization);

        public static readonly LinkRelation RedirectAuthorization =
            new LinkRelation(nameof(RedirectAuthorization), PaymentResourceOperations.RedirectAuthorization);

        public static readonly LinkRelation CreateSale = new LinkRelation(nameof(CreateSale), PaymentResourceOperations.CreateSale);

        public static readonly LinkRelation RedirectSale = new LinkRelation(nameof(RedirectSale), PaymentResourceOperations.RedirectSale);

        public static readonly LinkRelation ViewSales = new LinkRelation(nameof(ViewSales), PaymentResourceOperations.ViewSales);

        public static readonly LinkRelation AbortedPayment =
            new LinkRelation(nameof(AbortedPayment), PaymentResourceOperations.AbortedPayment);

        public static readonly LinkRelation RedirectAppSwish =
            new LinkRelation(nameof(RedirectAppSwish), PaymentResourceOperations.RedirectAppSwish);

        public static readonly LinkRelation ViewPayment = new LinkRelation(nameof(ViewPayment), PaymentResourceOperations.ViewPayment);

        public static readonly LinkRelation ViewVerification =
            new LinkRelation(nameof(ViewVerification), PaymentResourceOperations.ViewVerification);

        public static readonly LinkRelation UpdateAuthorizationOverchargedamount =
            new LinkRelation(nameof(UpdateAuthorizationOverchargedamount), PaymentResourceOperations.UpdateAuthorizationOverchargedAmount);
        public static readonly LinkRelation CreateApprovedLegalAddress =
            new LinkRelation(nameof(CreateApprovedLegalAddress), PaymentResourceOperations.CreateApprovedLegalAddress);

        public static readonly LinkRelation CreateAuthorization =
            new LinkRelation(nameof(CreateAuthorization), PaymentResourceOperations.CreateAuthorization);
            
        public static readonly LinkRelation DirectAuthorization = new LinkRelation(nameof(DirectAuthorization), PaymentResourceOperations.DirectAuthorization);


        public LinkRelation(string name, string value)
            : base(name, value)
        {
        }
    }
}