using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearDataStructures.DoublyLinkedList
{
	public class DoublyLinkedListNode<T>
	{
		public T ?Data { get; set; }
		public DoublyLinkedListNode<T> ?Next { get; set; } = null;
		public DoublyLinkedListNode<T> ?Previous { get; set; } = null;

        public DoublyLinkedListNode()
        {
            Next = null;
            Previous = null;
        }
        public DoublyLinkedListNode(T data, DoublyLinkedListNode<T> previous, DoublyLinkedListNode<T> next)
        {
			Data = data;
            Previous = previous;
            Next = next;
        }
    }
}
