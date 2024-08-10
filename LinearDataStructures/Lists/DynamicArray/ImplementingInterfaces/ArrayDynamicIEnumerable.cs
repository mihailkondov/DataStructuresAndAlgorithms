using System.Collections;
using System.Text;

namespace LinearDataStructures.Lists.DynamicArray.ImplementingInterfaces
{
	public class ArrayDynamicIEnumerable<T> : IEnumerable<T>
	{
		protected int _capacity = 2;
		protected T[] _array;
		public int Count { get; protected set; } = 0;
		public int Capacity { get => _capacity; protected set => _capacity = value; }

        public ArrayDynamicIEnumerable()
        {
			_array = new T[_capacity];
        }
        public ArrayDynamicIEnumerable(T[] dataArray)
        {
            _array = dataArray;
			_capacity = dataArray.Length;
			Count = _capacity;
        }

		public IEnumerator<T> GetEnumerator()
		{
			for(int i = 0; i < this._capacity; i++)
			{
				yield return _array[i];
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		/*
		public void Add(T data) 
		{ 
			if(this.Count >= _capacity)
			{
				this.Grow();
			}
			_array[Count] = data;
			this.Count++;
		}
		public void Insert(int  index, T data) 
		{
            if (index > this.Count || index < 0)
            {
				throw new ArgumentOutOfRangeException();
            }
            if (this.Count == _capacity)
			{
				this.Grow();
			}

			for(int i = this.Count; i > index; i--)
			{
				_array[i] = _array[i - 1];
			}
			_array[index] = data;
			this.Count++;
		} 
		public void Delete(T data)
		{
			int index = -1;
			for(int i = 0; i < this.Count; i++)
			{
				if (_array[i].Equals(data))
				{
					index = i; 
					break;	
				}
			}
			if(index > -1)
			{
				for(int i = index; i < this.Count - 1; i++)
				{
					_array[i] = _array[i + 1];
				}
				this.Count--;
				if (Count < _capacity / 3)
				{
					Shrink();
				}
			}
		}
		public int Search(T data) 
		{
			for (int i = 0; i < Count; i++) 
			{
				if (_array[i].Equals(data))
				{
					return i;
				}
			}

			return -1;
		}
		private void Grow() 
		{
			_capacity *= 2;
		}
		private void Shrink() 
		{
			_capacity /= 2;
		}
		public bool IsEmpty() 
		{
			if (Count > 0)
				return false;
			if (Count == 0)
				return true;
			throw new ArgumentOutOfRangeException(paramName: "Count", message:"DynamicArray Count property is negative");
		}
		*/
	}
}
