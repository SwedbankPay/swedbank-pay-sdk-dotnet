using System.Collections.Generic;

namespace SwedbankPay.Sdk
{
    /// <summary>
    /// Holds a list of <seealso cref="HttpOperation"/>s.
    /// </summary>
    public interface IOperationList : IList<HttpOperation>
    {
        /// <summary>
        /// Transforms the list to a string.
        /// </summary>
        /// <returns>The transformed string.</returns>
        string ToString();
    }
}