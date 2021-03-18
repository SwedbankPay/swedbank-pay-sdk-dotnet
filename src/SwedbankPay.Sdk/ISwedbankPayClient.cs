using SwedbankPay.Sdk.Consumers;
using SwedbankPay.Sdk.PaymentInstruments;
using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk
{
    /// <summary>
    /// The entrypoint of this SDK!
    /// Used to access the different APIs'.
    /// </summary>
    public interface ISwedbankPayClient
    {
        /// <summary>
        /// Resource to create and get payment orders.
        /// </summary>
        IPaymentOrdersResource PaymentOrders { get; }

        /// <summary>
        /// Resource to access consumer information.
        /// </summary>
        IConsumersResource Consumers { get; }

        /// <summary>
        /// Resource to create and get payments on several payment instruments.
        /// </summary>
        IPaymentInstrumentsResource Payments { get; }
    }
}
