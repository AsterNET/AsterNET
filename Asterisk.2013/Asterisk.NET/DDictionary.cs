using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsterNET
{
    public class DDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        //private readonly object lockThread = new object();
        private readonly IDictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
        private readonly TValue defaultValue = default(TValue);

        #region CONTRUTORES

        public DDictionary() { }

        public DDictionary(IDictionary<TKey, TValue> dictionary, TValue defaultValue)
        {
            this.dictionary = dictionary;
            this.defaultValue = defaultValue;
        }

        #endregion
        
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

        public TValue this[TKey key]
        {
            get
            {
                if (!dictionary.TryGetValue(key, out TValue value))
                    value = defaultValue;
                return value;
            }

            set { lock (dictionary) dictionary[key] = value; }
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
            bool resultado = !dictionary.TryGetValue(key, out value);
            if(!resultado) value = defaultValue;
            return resultado;            
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return dictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return dictionary.GetEnumerator();
        }        

        public ICollection<TKey> Keys
        {
            get {
                var keys = new List<TKey>();
                lock (dictionary) foreach(TKey key in dictionary.Keys) keys.Add(key);
                return keys;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                var values = new List<TValue>();
                lock (dictionary) foreach (TValue value in dictionary.Values) values.Add(value);              
                return values;
            }
        }
    }
}