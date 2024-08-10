using LinearDataStructures.LinkedList;
using System.ComponentModel;

namespace LinearDataStructures.Queue
{
	public class QueueDynamic<T> : IQueue<T>
	{
		private ListDoublyLinked<T> list;
		private ListDoublyLinkedNode<T>? Oldest;
		private ListDoublyLinkedNode<T>? Newest;

		public QueueDynamic()
		{
			list = new ListDoublyLinked<T>();
			Oldest = list.Head;
			Newest = list.Head;
		}

		public QueueDynamic(T data) : this()
		{
			list.Add(data);
		}

		public int Count
		{
			get
			{
				return list.Count;
			}
		}

		//This is not really needed here, but since I have the same property on the Static Queue I decided to add it here as well for consistency reasons.
        public int Capacity { get => list.Count;}
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
				if (Newest == null)
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
			if (Count == 0)
			{
				throw new InvalidOperationException("Queue is empty");
			}

			T result = list[0];
			list.RemoveAt(0);

			if (Count == 0)
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

		public void Clear()
		{
			list = new ListDoublyLinked<T>();
			Oldest = list.Head;
			Newest = list.Head;
		}

		public bool Contains(T data)
		{
			if (list.Search(data) != -1)
			{
				return true;
			}

			return false;
		}

		public T[] ToArray()
		{
			T[] array = new T[list.Count];
			int i = 0;
			ListDoublyLinkedNode<T> current = list.Head;

			while(current != null)
			{
				array[i] = current.Data;
				current = current.Next;
				i++;
			}

			return array;
		}

		public void TrimExcess()
		{
			throw new WarningException("TrimExcess does nothing for a linked list implementation of a Queue. Using this method is not needed.");
		}
	}
}
