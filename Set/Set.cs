using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set
{
    public class Set<T> : IEnumerable<T> where T : IComparable
    {
        private readonly List<T> _items = new List<T>();

        public Set()
        {
        }

        public Set(IEnumerable<T> items)
        {
            AddRange(items);
        }

        public void Add(T item)
        {
            if (Contains(item))
            {
                throw new InvalidOperationException("Item already exists in Set");
            }

            _items.Add(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                Add(item);
            }
        }

        public bool Remove(T item)
        {
            return _items.Remove(item);
        }

        public bool Contains(T item)
        {
            if (_items.Contains(item))
            {
                return true;
            }

            return false;
        }

        public int Counts
        {
            get
            {
                return _items.Count();
            }
        }

        public Set<T> Union(Set<T> other)
        {
            Set<T> result = new Set<T>(_items);
            result.addRangeSkipDuplicates(other._items);

            return result;
        }

        private void addRangeSkipDuplicates(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                addSkipDuplicates(item);
            }
        }

        private void addSkipDuplicates(T item)
        {
            if (!_items.Contains(item))
            {
                _items.Add(item);
            }
        }

        public Set<T> Intersection(Set<T> otherSet)
        {
            Set<T> result = new Set<T>();

            foreach (T item in _items)
            {
                if (otherSet.Contains(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public Set<T> Difference(Set<T> other)
        {
            Set<T> result = new Set<T>(_items);

            foreach (T item in other._items)
            {
                result.Remove(item);
            }

            return result;
        }

        public Set<T> SymetricDifference(Set<T> other)
        {
            Set<T> union = Union(other);
            Set<T> intersection = Intersection(other);

            return union.Difference(intersection);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
