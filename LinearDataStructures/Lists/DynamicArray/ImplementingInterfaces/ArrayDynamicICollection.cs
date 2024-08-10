﻿using System.Collections;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LinearDataStructures.Lists.DynamicArray.ImplementingInterfaces
{
	public class ArrayDynamicICollection<T> : ArrayDynamicIEnumerable<T>, ICollection<T>
	{
		public ArrayDynamicICollection()
			: base() { }

		public ArrayDynamicICollection(T[] data)
			: base(data) { }

		public bool IsReadOnly => throw new NotImplementedException();

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
