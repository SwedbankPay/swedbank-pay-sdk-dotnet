using System.Collections;
using System.Collections.Generic;

namespace SwedbankPay.Sdk
{
    public abstract class OperationsBase: IDictionary<LinkRelation, HttpOperation>
    {
        private readonly Dictionary<LinkRelation, HttpOperation> internalDictionary = new Dictionary<LinkRelation, HttpOperation>();

        public ICollection<LinkRelation> Keys => this.internalDictionary.Keys;

        public ICollection<HttpOperation> Values => this.internalDictionary.Values;

        public int Count => this.internalDictionary.Count;

        public bool IsReadOnly => false;

        HttpOperation IDictionary<LinkRelation, HttpOperation>.this[LinkRelation rel] { get => this.internalDictionary.ContainsKey(rel) ? this.internalDictionary[rel] : null; set => this.internalDictionary[rel] = value; }

        public IEnumerator GetEnumerator() => this.internalDictionary.GetEnumerator();
        public void Add(LinkRelation key, HttpOperation value) => this.internalDictionary.Add(key, value);
        public bool ContainsKey(LinkRelation key) => this.internalDictionary.ContainsKey(key);
        public bool Remove(LinkRelation key) => this.internalDictionary.Remove(key);
        public bool TryGetValue(LinkRelation key, out HttpOperation value) => this.internalDictionary.TryGetValue(key, out value);
        public void Add(KeyValuePair<LinkRelation, HttpOperation> item) => this.internalDictionary[item.Key] = item.Value;
        public void Clear() => this.internalDictionary.Clear();
        public bool Contains(KeyValuePair<LinkRelation, HttpOperation> item) => this.internalDictionary.ContainsKey(item.Key) && this.internalDictionary[item.Key].Equals(item.Value);
        public void CopyTo(KeyValuePair<LinkRelation, HttpOperation>[] array, int arrayIndex) => ((IDictionary)this.internalDictionary).CopyTo(array, arrayIndex);
        public bool Remove(KeyValuePair<LinkRelation, HttpOperation> item) => this.internalDictionary.Remove(item.Key);
        IEnumerator<KeyValuePair<LinkRelation, HttpOperation>> IEnumerable<KeyValuePair<LinkRelation, HttpOperation>>.GetEnumerator() => this.internalDictionary.GetEnumerator();
        public HttpOperation this[LinkRelation rel] => ContainsKey(rel) ? this.internalDictionary[rel] : null;
    }
}
