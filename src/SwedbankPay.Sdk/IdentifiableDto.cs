namespace SwedbankPay.Sdk;

internal record IdentifiableDto
{
    /// <summary>
    /// Instantiates and sets the <see cref="Id"/> of the <see cref="Identifiable"/>.
    /// </summary>
    /// <param name="id">The unique ID of this resource.</param>
    internal IdentifiableDto(string id)
    {
        Id = id;
    }

    /// <summary>
    ///     Relative URL to the resource
    /// </summary>
    public string Id { get; }
}