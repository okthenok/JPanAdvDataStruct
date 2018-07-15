using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPanAdvDataStructure
{
    public class MyLinkedList<T>
    {
        class Node
        {
            public T Value;
            public Node Next;
        }

        Node head;
        
        public MyLinkedList()
        {
            head = null;
        }
        public void AddEnd(T value)
        {
            if (head == null)
            {
                head = new Node();
                head.Value = value;
                return;
            }
            var curr = head;
            while(curr.Next != null)
            {
                curr = curr.Next;
            }
            curr.Next = new Node();
            curr.Next.Value = value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }

            yield return default(T);
        }
    }
}
