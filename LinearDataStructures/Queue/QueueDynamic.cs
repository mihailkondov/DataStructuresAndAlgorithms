using LinearDataStructures.LinkedList;

namespace LinearDataStructures.Queue
{
	public class QueueDynamic<T> : IQueue<T>
	{
		private ListDoublyLinked<T> list;
		private ListDoublyLinkedNode<T>? Oldest;
		private ListDoublyLinkedNode<T>? Newest;

        public QueueDynamic()
        {
            list = new ListDoublyLinked<T> ();
			Oldest = list.Head;
			Newest = list.Head;
        }

        public QueueDynamic(T data) : this() 
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
