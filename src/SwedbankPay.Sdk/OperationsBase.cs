using System.Collections;

namespace SwedbankPay.Sdk;

public class OperationsBase : IDictionary<LinkRelation, HttpOperation?>
{
    private readonly Dictionary<LinkRelation, HttpOperation?> _internalDictionary = new();

    public IEnumerator<KeyValuePair<LinkRelation, HttpOperation?>> GetEnumerator() => _internalDictionary.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _internalDictionary.GetEnumerator();

    public void Add(KeyValuePair<LinkRelation, HttpOperation?> item) => _internalDictionary[item.Key] = item.Value;


    public void Clear() => _internalDictionary.Clear();


    public bool Contains(KeyValuePair<LinkRelation, HttpOperation?> item) => _internalDictionary.ContainsKey(item.Key) &&
                                                                             _internalDictionary[item.Key]!
                                                                                 .Equals(item.Value);

    public void CopyTo(KeyValuePair<LinkRelation, HttpOperation?>[] array, int arrayIndex) =>
        ((IDictionary)_internalDictionary).CopyTo(array, arrayIndex);

    public bool Remove(KeyValuePair<LinkRelation, HttpOperation?> item) => _internalDictionary.Remove(item.Key);

    public int Count => _internalDictionary.Count;
    public bool IsReadOnly => false;

    public void Add(LinkRelation key, HttpOperation? value) => _internalDictionary.Add(key, value);

    public bool ContainsKey(LinkRelation key) => _internalDictionary.ContainsKey(key);

    public bool Remove(LinkRelation key) => _internalDictionary.Remove(key);

    public bool TryGetValue(LinkRelation key, out HttpOperation? value) =>
        _internalDictionary.TryGetValue(key, out value);

    public HttpOperation? this[LinkRelation key]
    { get => _internalDictionary.ContainsKey(key) ? _internalDictionary[key] : null; set => _internalDictionary[key] = value; }

    public ICollection<LinkRelation> Keys => _internalDictionary.Keys;
    public ICollection<HttpOperation?> Values => _internalDictionary.Values;
}