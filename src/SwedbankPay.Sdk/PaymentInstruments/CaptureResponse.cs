using System;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class CaptureResponse : ICaptureResponse
    {
        public CaptureResponse(Uri payment, ITransaction capture)
        {
            Payment = payment;
            Capture = capture;
        }

        /// <summary>
        /// A unique <seealso cref="Uri"/> to access this resource.
        /// </summary>
        public Uri Payment { get; }

        /// <summary>
        /// Holds transactional information about this capture.
        /// </summary>
        public ITransaction Capture { get; }
    }
}