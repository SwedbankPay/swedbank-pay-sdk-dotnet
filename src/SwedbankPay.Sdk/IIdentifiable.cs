using System;

namespace SwedbankPay.Sdk
{
    /// <summary>
    /// Contains a <seealso cref="Uri"/> to a uniquely identifiable resource.
    /// </summary>
    public interface IIdentifiable
    {
        /// <summary>
        /// The relative URI and unique identifier of the payment resource .
        /// </summary>
        Uri Id { get; }
    }
}