using System;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    /// <summary>
    /// Holds information about a captured payment.
    /// </summary>
    internal class CaptureResponse : ICaptureResponse
    {
        public CaptureResponse(CaptureResponseDto dto)
        {
            Payment = new Uri(dto.Payment, UriKind.RelativeOrAbsolute);
            Capture = dto.Capture.Map();
        }

        /// <summary>
        /// Instantiates a new <seealso cref="CaptureResponse"/> with the provided parameters.
        /// </summary>
        /// <param name="payment"><seealso cref="Uri"/> of the payment.</param>
        /// <param name="capture">Transactional details about the capture.</param>
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