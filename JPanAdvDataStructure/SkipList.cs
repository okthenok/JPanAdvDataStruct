using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JPanAdvDataStructure
{
    public class SkipList<T> : ICollection<T> where T : IComparable<T>
    {
        Node head;
        Node[] collection;

        public class Node
        {
            public T Value;
            public int Height = 1;
            public Node[] Nexts;
            public Node(T value)
            {
                Value = value;
            }
        }

        public SkipList() { }

        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        public void ChooseRandomHeight(Node node)
        {
            Random rand = new Random();
            while (rand.Next(0, 1) == 0 && node.Height < head.Height + 1)
            {
                node.Height++;
            }
            node.Nexts = new Node[node.Height];
            if (head.Height < node.Height)
            {
                head.Height = node.Height;
                head.Nexts = new Node[head.Height];
            }
        }

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            Node node = new Node(item);
            ChooseRandomHeight(node);
            AddItem(node, head);
        }

        public void AddItem(Node node, Node curr)
        {
            //move down
            for (int level = curr.Nexts.Length - 1; level >= 0; level--)
            {
                if (curr.Nexts[level] == null || curr.Nexts[level].Value.CompareTo(node.Value) > 0)
                {
                    if (node.Height < level)
                    {
                        //link curr
                        node.Nexts[level] = curr.Nexts[level];
                        curr.Nexts[level] = node;
                    }
                    continue;
                }
                else if (head.Nexts[level].Value.CompareTo(node.Value) < 0)
                {
                    //moves curr to right
                    curr = curr.Nexts[level];
                    level++;
                }
            }
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (Node n in collection)
            {
                yield return n.Value;
            }
        }

        public bool Remove(T item)
        {
            RemoveItem()
        }
        public bool RemoveItem(, Node curr)
        {

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


    }
}
