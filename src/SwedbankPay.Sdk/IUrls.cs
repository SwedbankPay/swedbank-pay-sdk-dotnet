using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk
{
    /// <summary>
    /// Resource to access the URLs used for a payment resource.
    /// </summary>
    public interface IUrls
    {
        /// <summary>
        /// The URI to the API endpoint receiving POST requests on transaction activity related to the payment.
        /// </summary>
        Uri CallbackUrl { get; }

        /// <summary>
        /// The URI to redirect the payer to if the payment is canceled,
        /// either by the payer or by the merchant trough an abort request of the payment or paymentorder.
        /// </summary>
        Uri CancelUrl { get; }

        /// <summary>
        /// The URL that Swedbank Pay will redirect back to when the payer has completed his or her interactions with the payment.
        /// This does not indicate a successful payment, only that it has reached a final (complete) state.
        /// A GET request needs to be performed on the payment order to inspect it further.
        /// </summary>
        Uri CompleteUrl { get; }

        /// <summary>
        /// The array of URIs valid for embedding of Swedbank Pay Hosted Views.
        /// </summary>
        ICollection<Uri> HostUrls { get; }

        /// <summary>
        /// The URL that will be used for showing the customer logo.
        /// Must be a picture with maximum 50px height and 400px width.
        /// Requires HTTPS.
        /// </summary>
        Uri LogoUrl { get; }

        /// <summary>
        /// With permission and activation on your contract,
        /// sending in a logoUrl will replace the Swedbank Pay logo with the logo sent in.
        /// If you do not send in a logoUrl, then no logo and no text is shown.
        /// Without permission or activation on your contract, sending in a logoUrl has no effect.
        /// </summary>
        Uri PaymentUrl { get; }

        /// <summary>
        /// The URI to the terms of service document the payer must accept in order to complete the payment.
        /// Note that this field is not required unless generateReferenceToken or generateRecurrenceToken is also submitted in the request.
        /// This is the Merchants, not the Swedbank Pay Terms of Service.
        /// HTTPS is a requirement.
        /// </summary>
        Uri TermsOfServiceUrl { get; }
    }
}