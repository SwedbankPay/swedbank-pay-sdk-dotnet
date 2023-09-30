namespace SwedbankPay.Sdk;

/// <summary>
/// Contains the MetaData for a Payment/PaymentOrder.
/// </summary>
public class Metadata : Dictionary<string, object>
{
    private const string ForbiddenKey = "id";

    /// <summary>
    /// Instantiates a new empty <seealso cref="Metadata"/>.
    /// </summary>
    public Metadata()
    {
    }

    /// <summary>
    /// Instantiates a new <seealso cref="Metadata"/> using the provided <seealso cref="Dictionary{TKey, TValue}"/>.
    /// </summary>
    /// <param name="dictionary">A <seealso cref="Dictionary{TKey, TValue}"/> with values to be added.</param>
    public Metadata(Dictionary<string, object> dictionary)
        : base(dictionary)
    {
        if (ContainsKey(ForbiddenKey))
        {
            Id = dictionary[ForbiddenKey].ToString();
            Remove(ForbiddenKey);
        }
    }

    /// <summary>
    /// Unique ID that references this resource, available if set.
    /// </summary>
    public string Id { get; }
}