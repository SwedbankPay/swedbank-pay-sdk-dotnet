using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    /// <summary>
    /// Maps the currently known operations for a Swish payment.
    /// </summary>
    public interface ISwishPaymentOperations : IDictionary<LinkRelation, HttpOperation>
    {
        /// <summary>
        /// Aborts the current payment, if available.
        /// </summary>
        Func<PaymentAbortRequest, Task<ISwishPaymentResponse>> Abort { get; }

        /// <summary>
        /// Gives access to retreiving a paid payment, if available.
        /// </summary>
        HttpOperation PaidPayment { get; }

        /// <summary>
        /// Gives access to redirecting a payer to complete a sales transaction, if available.
        /// </summary>
        HttpOperation RedirectSale { get; }

        /// <summary>
        /// Reverses the current payment, if available.
        /// </summary>
        Func<SwishPaymentReversalRequest, Task<IReversalResponse>> Reverse { get; }

        /// <summary>
        /// Initiates a sales transaction, if available.
        /// </summary>
        Func<SwishPaymentSaleRequest, Task<ISwishPaymentSaleResponse>> Sale { get; }

        /// <summary>
        /// Gives access to view sales transactions on the payment, if available.
        /// </summary>
        HttpOperation ViewSales { get; }
    }
}