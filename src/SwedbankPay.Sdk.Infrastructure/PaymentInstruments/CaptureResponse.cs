using System;

namespace SwedbankPay.Sdk.PaymentInstruments;

/// <summary>
/// Holds information about a captured payment.
/// </summary>
internal class CaptureResponse : ICaptureResponse
{
    public CaptureResponse(CaptureResponseDto dto)
    {
        Payment = dto.Payment;
        Capture = dto.Capture.Map();
    }

    /// <summary>
    /// A unique <seealso cref="Uri"/> to access this resource.
    /// </summary>
    public Uri Payment { get; }

    /// <summary>
    /// Holds transactional information about this capture.
    /// </summary>
    public ITransactionResponse Capture { get; }
}