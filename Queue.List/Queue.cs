using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.List
{
    public class Queue<T> : IEnumerable<T>
    {
        LinkedList<T> _items = new LinkedList<T> ();

        public void Enqueue(T item)
        {
            _items.AddLast(item);
        }

        public T Peek()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            return _items.First.Value;
        }

        public T Dequeue()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            T val = _items.First.Value;
            _items.RemoveFirst();

            return val;
        }

        public int Count
        {
            get
            {
                return _items.Count();
            }
        }

        public void Clear()
        {
            _items.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
