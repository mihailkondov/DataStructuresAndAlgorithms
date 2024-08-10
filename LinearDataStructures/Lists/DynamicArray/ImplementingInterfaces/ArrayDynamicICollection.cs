using System.Collections;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LinearDataStructures.Lists.DynamicArray.ImplementingInterfaces
{
	public class ArrayDynamicICollection<T> : ArrayDynamicIEnumerable<T>, ICollection<T>
	{
		//private T[] array;
		//public int Count { get => base.Count; protected set => base.Count = value; } = 0;
		//public int Capacity { get => base.Capacity; protected set => base.Capacity = value; }

		public ArrayDynamicICollection()
			: base() { }

		public ArrayDynamicICollection(T[] data)
			: base(data) { }

		public bool IsReadOnly => throw new NotImplementedException();
        
		//public IEnumerator<T> GetEnumerator()
        //{
        //	for (int i = 0; i < this._capacity; i++)
        //	{
        //		yield return _array[i];
        //	}
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //	return this.GetEnumerator();
        //}

        protected void Grow()
		{
			_capacity *= 2;
		}
		protected void Shrink()
		{
			_capacity /= 2;
		}

		public void Add(T data)
		{
			if (Count >= _capacity)
			{
				this.Grow();
			}
			_array[Count] = data;
			this.Count++;
		}

		public void Clear()
		{
			_capacity = 2;
			_array = new T[_capacity];
			Count = 0;
		}

		public bool Contains(T item)
		{
			for (int i = 0; i < Count; i++)
			{
				if (_array[i].Equals(item))
				{
					return true;
				}
			}

			return false;
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			for (int i = 0; i < Count; i++)
			{
				array[arrayIndex+i] = _array[i];
			}
		}

		public bool Remove(T item)
		{
			int index = Search(item);

			if(index < 0) 
			{
				return false;
			}

			for(int i = index; i < Count - 1; i++)
			{
				_array[i] = _array[i + 1];
			}

			if(Count * 3 < _capacity)
			{
				Shrink();
			}

			return true;
		}

		/*
		public void Insert(int index, T data)
		{
			if (index > this.Count || index < 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			if (this.Count == _capacity)
			{
				this.Grow();
			}

			for (int i = this.Count; i > index; i--)
			{
				_array[i] = _array[i - 1];
			}
			_array[index] = data;
			this.Count++;
		}

		public void Delete(T data)
		{
			int index = -1;
			for (int i = 0; i < this.Count; i++)
			{
				if (_array[i].Equals(data))
				{
					index = i;
					break;
				}
			}
			if (index > -1)
			{
				for (int i = index; i < this.Count - 1; i++)
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

		public bool IsEmpty()
		{
			if (Count > 0)
				return false;
			if (Count == 0)
				return true;
			throw new ArgumentOutOfRangeException(paramName: "Count", message: "DynamicArray Count property is negative");
		}
		*/
		private int Search(T data)
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
	}
}
