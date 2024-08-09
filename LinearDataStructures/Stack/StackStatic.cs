namespace LinearDataStructures.Stack
{
	/// <summary>
	/// Stack implementation using a dynamic array to hold the data
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class StackStatic<T> : IStack<T>
	{
		private static readonly int _initialCapacity = 2;
		private int _capacity = _initialCapacity;
		private T[] _dataArray = new T[_initialCapacity];
		private int _top = -1;

		public StackStatic()
		{

		}

		public StackStatic(T data)
		{
			Push(data);
		}

		public StackStatic(ICollection<T> data)
		{
			foreach (var item in data) 
			{
				Push(item);
			}
		}

		public int Count { get; private set; } = 0;

		/// <summary>
		/// Cuts the capacity of the data array in half
		/// </summary>
        private void Shrink()
		{
			T[] temporary = _dataArray;
			_capacity /= 2;
			_dataArray = new T[_capacity];

			for (int i = 0; i < _dataArray.Length; i++)
			{
				_dataArray[i] = temporary[i];
			}
		}

		/// <summary>
		/// Doubles the capacity of the data array
		/// </summary>
		private void Grow()
		{
			T[] temporary = _dataArray;
			_capacity *= 2;
			_dataArray = new T[_capacity];

			for (int i = 0; i < temporary.Length; i++)
			{
				_dataArray[i] = temporary[i];	
			}
		}

        public T Peek()
		{
			return _dataArray[_top];
		}

		public T Pop()
		{
			T result = _dataArray[_top];
			_top--;
			Count--;

			if(Count * 3 < _capacity)
			{
				Shrink();
			}

			return result;
		}

		public void Push(T data)
		{
			if(Count == _capacity)
			{
				Grow();
			}

			_top++;
			_dataArray[_top] = data;
			Count++;
		}
	}
}
