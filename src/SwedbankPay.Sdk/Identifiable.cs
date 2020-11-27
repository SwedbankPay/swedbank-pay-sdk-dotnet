using System;

namespace SwedbankPay.Sdk
{
    /// <summary>
    /// Contains a <seealso cref="Uri"/> to a uniquely identifiable resource.
    /// </summary>
    public class Identifiable
    {
        /// <summary>
        ///     Relative URL to the resource
        /// </summary>
        public Uri Id { get; set; }
    }
}