namespace SwedbankPay.Sdk
{
    /// <summary>
    /// Class to describe problem responses in certain api responses.
    /// </summary>
    public interface IProblemResponseItem
    {
        /// <summary>
        /// The human readable description of what was wrong with the field,
        /// header, object, entity or likewise identified by <see cref="Name"/>.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// The name of the field, header, object, entity or likewise that was erroneous.
        /// </summary>
        string Name { get; }
    }
}