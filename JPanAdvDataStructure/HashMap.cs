using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPanAdvDataStructure
{
    //class Derp
    //{
    //    public int x;
    //}

    public class HashMap<TKey, TValue> : IDictionary<TKey, TValue>
    {
        LinkedList<KeyValuePair<TKey, TValue>>[] pairs;
        int arraySize = 10;
        #region idictionary and iequalitycomparer stuff

        IEqualityComparer<TKey> comparer;

        public HashMap(IEqualityComparer<TKey> Comparer = null)
        {
            //inline if
            //int x = 4 > 5 ? 3 : 6;

            //inline null check
            this.comparer = Comparer ?? EqualityComparer<TKey>.Default;

            if (Comparer == null)
            {
                this.comparer = EqualityComparer<TKey>.Default;
            }
            else
            {
                this.comparer = Comparer;
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ICollection<TKey> Keys
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public void Add(TKey key, TValue value)
        {
            int hash = comparer.GetHashCode(key);
            int index = hash % arraySize;
            KeyValuePair<TKey, TValue> pair = new KeyValuePair<TKey, TValue>(key, value);
            if (pairs[index] == null)
            {
                pairs[index] = pairs[index].AddFirst(pair);
            }
            //else if (pairs[index].Contains(key))

            //if(comparer.Equals(key, otherKey))
            //{
                //
            //}

            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(TKey key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
