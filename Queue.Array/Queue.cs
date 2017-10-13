using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Array
{
    public class Queue<T> : IEnumerable<T>
    {
        T[] _items = new T[0];
        int _size;
        int _head;
        int _tail = -1;

        public void Enqueue(T item)
        {
            if (_items.Length == _size)
            {
                int newLen = _size == 0 ? 4 : _size * 2;
                T[] newArr = new T[newLen];

                if (_size == 0)
                {
                    int targetIndex = 0;

                    if (_tail < _head)
                    {
                        for (int index = _head; index < _items.Length; ++index)
                        {
                            newArr[targetIndex] = _items[index];
                            ++targetIndex;
                        }

                        for (int index = 0; index < _tail; ++index)
                        {
                            newArr[targetIndex] = _items[index];
                            ++targetIndex;
                        }
                    }
                    else
                    {
                        for (int index = _head; index <= _tail; ++index)
                        {
                            newArr[targetIndex] = _items[index];
                            ++targetIndex;
                        }
                    }

                    _head = 0;
                    _tail = targetIndex - 1;
                }
                else
                {
                    _head = 0;
                    _tail = -1;
                }

                _items = newArr;
            }

            if (_tail == _items.Length - 1)
            {
                _tail = 0;
            }
            else
            {
                _tail++;
            }

            _items[_tail] = item;
        }

        public T Dequeue()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            T val = _items[_head];

            if (_head == _items.Length-1)
            {
                _head = 0;
            }
            else
            {
                ++_head;
            }

            --_size;

            return val;
        }

        public T Peek()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            return _items[_head];
        }

        public int Count
        {
            get
            {
                return _size;
            }
        }

        public void Clear()
        {
            _size = 0;
            _head = 0;
            _tail = -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (_size > 0)
            {
                if (_tail < _head)
                {
                    for (int i = _head; i < _items.Length; ++i)
                    {
                        yield return _items[i];
                    }

                    for (int i = 0; i < _tail; ++i)
                    {
                        yield return _items[i];
                    }
                }
                else
                {
                    for (int i = _head; i < _tail; ++i)
                    {
                        yield return _items[i];
                    }
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
