using System.Collections;

namespace SwedbankPay.Sdk;

public class OperationsBase : IDictionary<LinkRelation, HttpOperation>
{
    private readonly Dictionary<LinkRelation, HttpOperation?> internalDictionary = new();

    public IEnumerator<KeyValuePair<LinkRelation, HttpOperation>> GetEnumerator() => internalDictionary.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => internalDictionary.GetEnumerator();

    public void Add(KeyValuePair<LinkRelation, HttpOperation> item) => internalDictionary[item.Key] = item.Value;


    public void Clear() => internalDictionary.Clear();


    public bool Contains(KeyValuePair<LinkRelation, HttpOperation> item) => internalDictionary.ContainsKey(item.Key) &&
                                                                            internalDictionary[item.Key]!
                                                                                .Equals(item.Value);

    public void CopyTo(KeyValuePair<LinkRelation, HttpOperation>[] array, int arrayIndex) =>
        ((IDictionary)internalDictionary).CopyTo(array, arrayIndex);

    public bool Remove(KeyValuePair<LinkRelation, HttpOperation> item) => internalDictionary.Remove(item.Key);

    public int Count => internalDictionary.Count;
    public bool IsReadOnly => false;

    public void Add(LinkRelation key, HttpOperation value) => internalDictionary.Add(key, value);

    public bool ContainsKey(LinkRelation key) => internalDictionary.ContainsKey(key);

    public bool Remove(LinkRelation key) => internalDictionary.Remove(key);

    public bool TryGetValue(LinkRelation key, out HttpOperation value) =>
        internalDictionary.TryGetValue(key, out value);

    public HttpOperation this[LinkRelation key]
    { get => internalDictionary.ContainsKey(key) ? internalDictionary[key] : null; set => internalDictionary[key] = value; }

    public ICollection<LinkRelation> Keys => internalDictionary.Keys;
    public ICollection<HttpOperation> Values => internalDictionary.Values;
}