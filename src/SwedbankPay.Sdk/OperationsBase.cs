using System.Collections;
using System.Collections.Generic;

namespace SwedbankPay.Sdk
{
    public abstract class OperationsBase : IDictionary<LinkRelation, HttpOperation>
    {
        private readonly Dictionary<LinkRelation, HttpOperation> internalDictionary = new Dictionary<LinkRelation, HttpOperation>();

        public ICollection<LinkRelation> Keys => internalDictionary.Keys;

        public ICollection<HttpOperation> Values => internalDictionary.Values;

        public int Count => internalDictionary.Count;

        public bool IsReadOnly => false;

        HttpOperation IDictionary<LinkRelation, HttpOperation>.this[LinkRelation rel] { get => internalDictionary.ContainsKey(rel) ? internalDictionary[rel] : null; set => internalDictionary[rel] = value; }

        public IEnumerator GetEnumerator() => internalDictionary.GetEnumerator();
        public void Add(LinkRelation key, HttpOperation value) => internalDictionary.Add(key, value);
        public bool ContainsKey(LinkRelation key) => internalDictionary.ContainsKey(key);
        public bool Remove(LinkRelation key) => internalDictionary.Remove(key);
        public bool TryGetValue(LinkRelation key, out HttpOperation value) => internalDictionary.TryGetValue(key, out value);
        public void Add(KeyValuePair<LinkRelation, HttpOperation> item) => internalDictionary[item.Key] = item.Value;
        public void Clear() => internalDictionary.Clear();
        public bool Contains(KeyValuePair<LinkRelation, HttpOperation> item) => internalDictionary.ContainsKey(item.Key) && internalDictionary[item.Key].Equals(item.Value);
        public void CopyTo(KeyValuePair<LinkRelation, HttpOperation>[] array, int arrayIndex) => ((IDictionary)internalDictionary).CopyTo(array, arrayIndex);
        public bool Remove(KeyValuePair<LinkRelation, HttpOperation> item) => internalDictionary.Remove(item.Key);
        IEnumerator<KeyValuePair<LinkRelation, HttpOperation>> IEnumerable<KeyValuePair<LinkRelation, HttpOperation>>.GetEnumerator() => internalDictionary.GetEnumerator();
        public HttpOperation this[LinkRelation rel] => ContainsKey(rel) ? internalDictionary[rel] : null;
    }
}
