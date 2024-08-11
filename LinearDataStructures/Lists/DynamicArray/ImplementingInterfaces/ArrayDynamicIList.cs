using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LinearDataStructures.Lists.DynamicArray.ImplementingInterfaces
{
	public class ArrayDynamicIList<T> : ArrayDynamicICollection<T>, IList<T>
	{
        public ArrayDynamicIList() 
			: base() { }

        public ArrayDynamicIList(T[] data) 
			: base(data) { }

        public T this[int index]
		{
			get 
			{
				if(index < 0 || index >= Count)
				{
					throw new IndexOutOfRangeException();
				}
				else
				{
					return _array[index];
				}
			}

			set
			{
				if (index < 0 || index >= Count)
				{
					throw new IndexOutOfRangeException();
				}
				else
				{
					_array[index] = value;
				}
			}
		}

		public int IndexOf(T item)
		{
			for (int i = 0; i < Count; i++)
			{
				if (_array[i].Equals(item))
				{
					return i;
				}
			}

			return -1;
		}

		public void Insert(int index, T item)
		{
			if (index > Count || index < 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			if (Count == _capacity)
			{
				Grow();
			}

			for (int i = Count; i > index; i--)
			{
				_array[i] = _array[i - 1];
			}
			_array[index] = item;
			Count++;
		}

		public void RemoveAt(int index)
		{
			if (index < 0 || index >= Count)
			{
				throw new IndexOutOfRangeException();
			}
			else
			{
				for (int i = index; i < Count - 1; i++)
				{
					_array[i] = _array[i + 1];
				}

				Count--;

				if (Count * 3 < _capacity)
				{
					Shrink();
				}
			}
		}
	}
}
