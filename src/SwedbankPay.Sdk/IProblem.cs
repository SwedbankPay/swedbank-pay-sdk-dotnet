using System.Collections.Generic;

namespace SwedbankPay.Sdk
{
    /// <summary>
    /// Holds details about a problem response from the API.
    /// </summary>
    public interface IProblem
    {
        /// <summary>
        /// The action indicates how the error can be recovered from.
        /// </summary>
        string Action { get; }

        /// <summary>
        /// A detailed, human readable description of the error and how you can recover from it.
        /// </summary>
        string Detail { get; }

        /// <summary>
        /// The identifier of the error instance.
        /// This might be of use to Swedbank Pay support personnel in order to find the exact error and the context it occurred in.
        /// </summary>
        string Instance { get; }

        /// <summary>
        /// Array of problem detail objects.
        /// </summary>
        IList<IProblemItem> Problems { get; }

        /// <summary>
        /// The HTTP status code that the problem was served with.
        /// </summary>
        int Status { get; }

        /// <summary>
        /// The title contains a human readable description of the error.
        /// </summary>
        string Title { get; }

        /// <summary>
        /// The URI that identifies the error type.
        /// This is the only field usable for programmatic identification of the type of error.
        /// When dereferenced,
        /// it might lead you to a human readable description of the error and how it can be recovered from.
        /// </summary>
        string Type { get; }
    }
}