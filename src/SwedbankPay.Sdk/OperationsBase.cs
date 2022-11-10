using System.Collections;
using System.Collections.Generic;

namespace SwedbankPay.Sdk;

/// <summary>
/// Abstract class to handle the relation between <seealso cref="LinkRelation"/> and <seealso cref="HttpOperation"/>.
/// </summary>
public abstract class OperationsBase : IDictionary<LinkRelation, HttpOperation>
{
    private readonly Dictionary<LinkRelation, HttpOperation> internalDictionary = new Dictionary<LinkRelation, HttpOperation>();

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public ICollection<LinkRelation> Keys => this.internalDictionary.Keys;

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public ICollection<HttpOperation> Values => this.internalDictionary.Values;

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public int Count => this.internalDictionary.Count;

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public bool IsReadOnly => false;

    HttpOperation IDictionary<LinkRelation, HttpOperation>.this[LinkRelation rel] { get => this.internalDictionary.ContainsKey(rel) ? this.internalDictionary[rel] : null; set => this.internalDictionary[rel] = value; }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public IEnumerator GetEnumerator() => this.internalDictionary.GetEnumerator();

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public void Add(LinkRelation key, HttpOperation value) => this.internalDictionary.Add(key, value);

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public bool ContainsKey(LinkRelation key) => this.internalDictionary.ContainsKey(key);

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public bool Remove(LinkRelation key) => this.internalDictionary.Remove(key);

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public bool TryGetValue(LinkRelation key, out HttpOperation value) => this.internalDictionary.TryGetValue(key, out value);

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public void Add(KeyValuePair<LinkRelation, HttpOperation> item) => this.internalDictionary[item.Key] = item.Value;

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public void Clear() => this.internalDictionary.Clear();

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public bool Contains(KeyValuePair<LinkRelation, HttpOperation> item) => this.internalDictionary.ContainsKey(item.Key) && this.internalDictionary[item.Key].Equals(item.Value);

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public void CopyTo(KeyValuePair<LinkRelation, HttpOperation>[] array, int arrayIndex) => ((IDictionary)this.internalDictionary).CopyTo(array, arrayIndex);

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public bool Remove(KeyValuePair<LinkRelation, HttpOperation> item) => this.internalDictionary.Remove(item.Key);

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    IEnumerator<KeyValuePair<LinkRelation, HttpOperation>> IEnumerable<KeyValuePair<LinkRelation, HttpOperation>>.GetEnumerator() => this.internalDictionary.GetEnumerator();

    /// <summary>
    /// Gets a <paramref name="rel"/> if the dictionary contains it, otherwise null.
    /// </summary>
    public HttpOperation this[LinkRelation rel] => ContainsKey(rel) ? this.internalDictionary[rel] : null;
}
