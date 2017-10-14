using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsterNET
{
    public class DDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly IDictionary<TKey, TValue> dictionary;
        private readonly TValue defaultValue;

        public DDictionary()
        {
            this.dictionary = new Dictionary<TKey, TValue>();
            this.defaultValue = default(TValue);
        }

        public DDictionary(IDictionary<TKey, TValue> dictionary, TValue defaultValue)
        {
            this.dictionary = dictionary;
            this.defaultValue = defaultValue;
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return dictionary.GetEnumerator();
        }

        #region MODIFICADORES

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            lock(dictionary) dictionary.Add(item);
        }

        public void Add(TKey key, TValue value)
        {
            lock (dictionary) dictionary.Add(key, value);
        }

        public bool Remove(TKey key)
        {
            bool retorno = false;
            lock (dictionary) retorno = dictionary.Remove(key);
            return retorno;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            bool retorno = false;
            lock (dictionary) retorno = dictionary.Remove(item);
            return retorno;
        }

        public void Clear()
        {
            lock(dictionary) dictionary.Clear();
        }

        #endregion

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return dictionary.Contains(item);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            dictionary.CopyTo(array, arrayIndex);
        }       

        public int Count
        {
            get { return dictionary.Count; }
        }

        public bool IsReadOnly
        {
            get { return dictionary.IsReadOnly; }
        }

        public bool ContainsKey(TKey key)
        {
            return dictionary.ContainsKey(key);
        }
                
        public bool TryGetValue(TKey key, out TValue value)
        {
            if (!dictionary.TryGetValue(key, out value))
            {
                value = defaultValue;
            }

            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return dictionary.GetEnumerator();
        }

        public TValue this[TKey key]
        {
            get
            {
                if (dictionary.ContainsKey(key))
                    return dictionary[key];
                else
                    return defaultValue;
            }

            set { dictionary[key] = value; }
        }

        public ICollection<TKey> Keys
        {
            get { return dictionary.Keys; }
        }

        public ICollection<TValue> Values
        {
            get
            {
                var values = new List<TValue>(dictionary.Values) {
                    defaultValue
                };
                return values;
            }
        }
    }
}