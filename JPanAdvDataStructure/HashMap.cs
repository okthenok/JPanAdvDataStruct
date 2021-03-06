﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPanAdvDataStructure
{
    public class HashMap<TKey, TValue> : IDictionary<TKey, TValue>
    {
        //variables
        public LinkedList<KeyValuePair<TKey, TValue>>[] pairs;
        IEqualityComparer<TKey> comparer;
        private const uint defaultCapacity = 10;

        //properties
        public int Count { get; private set; }
        public int Capacity => pairs.Length;

        //constructors
        public HashMap() : this(defaultCapacity, null) { }
        public HashMap(uint capacity) : this(capacity, null) { }
        public HashMap(IEqualityComparer<TKey> comparer) : this(defaultCapacity, comparer) { }
        public HashMap(uint capacity, IEqualityComparer<TKey> comparer)
        {
            Count = 0;
            if (capacity == 0) capacity = 1;
            this.comparer = comparer ?? EqualityComparer<TKey>.Default;
            pairs = new LinkedList<KeyValuePair<TKey, TValue>>[capacity];
        }

        //functions
        private void ReHash()
        {
            var temp = new LinkedList<KeyValuePair<TKey, TValue>>[Capacity * 2];
            for (int i = 0; i < Capacity; i++)
            {
                if (pairs[i] == null) continue;

                foreach (KeyValuePair<TKey, TValue> pair in pairs[i])
                {
                    int hash = comparer.GetHashCode(pair.Key);
                    int index = hash % (Capacity * 2);

                    if (temp[index] == null)
                    {
                        temp[index] = new LinkedList<KeyValuePair<TKey, TValue>>();
                    }
                    temp[index].AddFirst(pair);
                }
            }
            pairs = temp;
        }
        #region idictionary and iequalitycomparer stuff


        public TValue this[TKey key]
        {
            get
            {
                //using the key, find the value and return it
                //if the key doesnt exist
                //return value
                for (int i = 0; i < Capacity; i++)
                {
                    if (pairs[i] == null) continue;
                    foreach (KeyValuePair<TKey, TValue> pair in pairs[i])
                    {
                        if (comparer.Equals(key, pair.Key)) return pair.Value;
                    }
                }
                throw new KeyNotFoundException();
            }

            set
            {
                //using the key, find the value and change it to 
                if (ContainsKey(key))
                {
                    for (int i = 0; i < Capacity; i++)
                    {
                        if (pairs[i] == null) continue;
                        foreach (KeyValuePair<TKey, TValue> pair in pairs[i])
                        {
                            if (comparer.Equals(key, pair.Key))
                            {
                                pairs[i].Remove(pair);
                                pairs[i].AddFirst(new KeyValuePair<TKey, TValue>(key, value));
                                return;
                            }
                        }
                    }
                }
                else
                {
                    Add(key, value);
                }
            }
        }


        //explicit interface implementation
        public bool IsReadOnly => false;

        public ICollection<TKey> Keys => this.Select(x => x.Key).ToList();

        public ICollection<TValue> Values => this.Select(x => x.Value).ToList();

        //explicit interface implementation (optionally)
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Add(TKey key, TValue value)
        {
            Count++;
            if (Count == Capacity)
            {
                ReHash();
            }

            int hash = comparer.GetHashCode(key);
            int index = hash % Capacity;
            if (pairs[index] == null)
            {
                pairs[index] = new LinkedList<KeyValuePair<TKey, TValue>>();
            }
            //if the current linked list contains the key or not
            if (pairs[index].Select(x => x.Key).Contains(key))
            {
                throw new Exception("big bad");
            }
            else
            {
                pairs[index].AddFirst(new KeyValuePair<TKey, TValue>(key, value));
            }
        }

        public void Clear()
        {
            for (int i = 0; i < pairs.Length; i++)
            {
                pairs[i] = null;
            }
            pairs = new LinkedList<KeyValuePair<TKey, TValue>>[defaultCapacity];
        }

        public bool Contains(KeyValuePair<TKey, TValue> item) //dont need
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(TKey key) //needs
        {
            for (int i = 0; i < pairs.Length; i++)
            {
                if (pairs[i] == null) continue;
                foreach (KeyValuePair<TKey, TValue> pair in pairs[i])
                {
                    if (comparer.Equals(key, pair.Key))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) //dont need
        {
            throw new NotImplementedException();
        }



        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            int hash = comparer.GetHashCode(item.Key);
            int index = hash % Capacity;
            foreach (KeyValuePair<TKey, TValue> pair in pairs[index])
            {
                if (comparer.Equals(pair.Key, item.Key))
                {
                    pairs[index].Remove(pair);
                    Count--;
                    return true;
                }
            }
            return false;
        }

        public bool Remove(TKey key)
        {
            TValue value;
            if (TryGetValue(key, out value))
            {
                return Remove(new KeyValuePair<TKey, TValue>(key, value));
            }
            else
            {
                return false;
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            int hash = comparer.GetHashCode(key);
            int index = hash % Capacity;
            foreach (KeyValuePair<TKey, TValue> pair in pairs[index])
            {
                if (comparer.Equals(pair.Key, key))
                {
                    value = pair.Value;
                    return true;
                }
            }
            value = default(TValue);
            return false;
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() 
        {
            for (int i = 0; i < Capacity; i++)
            {
                if (pairs[i] == null)
                {
                    continue;
                }
                foreach (KeyValuePair<TKey, TValue> pair in pairs[i])
                {
                    yield return pair;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
