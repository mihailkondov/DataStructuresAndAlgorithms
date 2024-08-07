using LinearDataStructures.LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LinearDataStructures.Queue
{
	public class DynamicQueue<T>
	{
		private DoublyLinkedList<T> list;
		private DoublyLinkedListNode<T>? Oldest;
		private DoublyLinkedListNode<T>? Newest;

        public DynamicQueue()
        {
            list = new DoublyLinkedList<T> ();
			Oldest = list.Head;
			Newest = list.Head;
        }

        public DynamicQueue(T data) : this() 
        {
			list.Add(data);
        }

        public int Count {
			get
			{
				return list.Count;
			}
		}
        public void Enqueue(T item)
		{
			list.Add(item);
			if (Count == 1)
			{
				Oldest = list.Head;
				Newest = list.Head;
			}
			else
			{
				if(Newest == null)
				{
					Newest = list.Head;
				}
				else
				{
					Newest = Newest.Next;
				}
			}
		}

		public T Peek()
		{
			return Oldest.Data;
		}

		public T Dequeue() 
		{
			if(Count == 0)
			{
				throw new InvalidOperationException("Queue is empty");
			}

			T result = list[0];
			list.RemoveAt(0);

			if(Count == 0)
			{
				Oldest = null;
				Newest = null;
			}
			else if (Count == 1)
			{
				Oldest = Newest;
			}
			else
			{
				Oldest = Oldest.Next;
			}

			return result;
		}

	}
}
