namespace SwedbankPay.Sdk;

/// <summary>
/// Contains a <seealso cref="Uri"/> to a uniquely identifiable resource.
/// </summary>
public class Identifiable : IIdentifiable
{
    /// <summary>
    /// Instantiates and sets the <see cref="Id"/> of the <see cref="Identifiable"/>.
    /// </summary>
    /// <param name="id">The unique ID of this resource.</param>
    public Identifiable(Uri id)
    {
        Id = id;
    }

    /// <summary>
    /// Instantiates and sets the <see cref="Id"/> of the <see cref="Identifiable"/>.
    /// </summary>
    /// <param name="id">The unique ID of this resource.</param>
    internal Identifiable(string id)
    {
        Id = new Uri(id, UriKind.RelativeOrAbsolute);
    }

    /// <summary>
    ///     Relative URL to the resource
    /// </summary>
    public Uri Id { get; }
}