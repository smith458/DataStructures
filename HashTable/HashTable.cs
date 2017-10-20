using System;
using System.Collections.Generic;

namespace HashTable
{
    public class HashTable<TKey, TValue>
    {
        const double _fillFactor = .75;

        int _maxItemsAtCurrentSize;

        int _count;

        HashTableArray<TKey, TValue> _array;

        public HashTable() : this(1000)
        {
        }

        public HashTable(int initialCapacity)
        {
            //watch at 3:00
        }
    }
}
