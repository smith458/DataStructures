using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
{
    public class LinkedListNode<T>
    {
        public LinkedListNode(T value)
        {
            Value = value;
        }

        //The node value
        public T Value { get; set; }

        //The next node in the linked list
        public LinkedListNode<T> Next { get; set; }

        //The previous node in the linked list
        public LinkedListNode<T> Previous { get; set; }
    }
}
