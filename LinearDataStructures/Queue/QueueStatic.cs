namespace LinearDataStructures.Queue
{
	public class QueueStatic<T> : IQueue<T>
	{
		static int _initialCapacity = 2;
		private T[] _dataArray = new T[_initialCapacity];
		private int _head = 0;
		private int _tail = 0;
		private int _capacity = _initialCapacity;

		public int Count { get; private set; } = 0;

		private void Grow()
		{
			if(Count == 0)
			{
				_capacity = _initialCapacity;
				return;
			}

			T[] oldArray = _dataArray;
			T[] newArray = new T[oldArray.Length * 2];
			int oldCapacity = _capacity;
			_capacity = newArray.Length;

			int cursorNA = 0;
			int cursorOA = _head;
			while (cursorOA < oldCapacity)
			{
				newArray[cursorNA++] = oldArray[cursorOA++];
			}

			int countMinusOne = Count - 1;
			while (cursorNA < countMinusOne)
			{
				newArray[cursorNA] = oldArray[cursorOA - oldArray.Length];
				cursorNA++;
				cursorOA++;
			}

			_dataArray = newArray; 
			_head = 0;
			_tail = _head + _dataArray.Length - 1;
		}

		private void Shrink()
		{
			T[] oldArray = _dataArray;
			T[] newArray = new T[oldArray.Length / 2];
			int oldCapacity = _capacity;
			_capacity = newArray.Length;

			int cursorNA = 0;
			int cursorOA = _head;
			while (cursorOA < oldCapacity)
			{
				newArray[cursorNA++] = oldArray[cursorOA++];
			}

			int countMinusOne = Count - 1;
			while (cursorNA < countMinusOne)
			{
				newArray[cursorNA] = oldArray[cursorOA - oldArray.Length];
				cursorNA++;
				cursorOA++;
			}

			_dataArray = newArray;
			_head = 0;
			_tail = _head + _dataArray.Length - 1;
		}

        public T Dequeue()
		{
			if (Count == 0)
				throw new InvalidOperationException("Cannot dequeue from an empty queue.");

			if(Count * 3 < _capacity)
			{
				Shrink();
			}

			T result = _dataArray[_head++];
			if(_head == _capacity) // head carry over to the beginning instead of out of bounds
			{
				_head = 0;
			}

			Count--;
			return result;
		}

		public void Enqueue(T data)
		{
			if(Count == _capacity)
			{
				Grow();
			}

			_dataArray[_tail++] = data;
			if (_tail == _capacity)
			{
				_tail = 0;
			}

			Count++;
		}

		public T Peek()
		{
			if (Count == 0)
				throw new InvalidOperationException("Queue is empty. Can only peek in a queue with 1 or more members");

			return _dataArray[_head];
		}
	}
}
