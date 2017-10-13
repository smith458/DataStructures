using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Priority
{
    public class PriorityQueue<T> : IEnumerable<T> where T: IComparable<T>
    {
        private LinkedList<T> _items = new LinkedList<T>();

        public void Enqueue(T item)
        {
            if (_items.Count == 0)
            {
                _items.AddLast(item);
            }
            else
            {
                var current = _items.First;
                while (current != null && current.Value.CompareTo(item) > 0)
                {
                    current = current.Next;
                }

                if (current == null)
                {
                    _items.AddLast(item);
                }
                else
                {
                    _items.AddBefore(current, item);
                }

            }
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
