using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArrays
{
	internal class DynamicArray
	{
		internal int capacity = 10;
		internal int Count { get; private set; } = 0;
		internal object[] array;

        public DynamicArray()
        {
			this.array = new object[capacity];
        }
        public DynamicArray(int capacity)
        {
            this.array = new object[capacity];
        }

		public void Add(object data) 
		{ 
			if(this.Count >= capacity)
			{
				this.Grow();
			}
			array[Count] = data;
			this.Count++;
		}
		public void Insert(int  index, object data) 
		{
            if (index > this.Count || index < 0)
            {
				throw new ArgumentOutOfRangeException();
            }
            if (this.Count == capacity)
			{
				this.Grow();
			}

			for(int i = this.Count; i > index; i--)
			{
				array[i] = array[i - 1];
			}
			array[index] = data;
			this.Count++;
		} 
		public void Delete(object data)
		{
			int index = -1;
			for(int i = 0; i < this.Count; i++)
			{
				if (array[i] == data)
				{
					index = i; 
					break;	
				}
			}
			if(index > -1)
			{
				for(int i = index; i < this.Count - 1; i++)
				{
					array[i] = array[i + 1];
				}
				this.Count--;
				if (Count < capacity / 3)
				{
					Shrink();
				}
			}
		}
		public int Search(object data) 
		{
			for (int i = 0; i < Count; i++) 
			{
				if (array[i].Equals(data))
				{
					return i;
				}
			}

			return -1;
		}
		private void Grow() 
		{
			capacity *= 2;
		}
		private void Shrink() 
		{
			capacity /= 2;
		}
		public bool IsEmpty() 
		{
			throw new NotImplementedException();
		}
		public override string ToString() 
		{
			StringBuilder sb = new StringBuilder("[");
			for(int i = 0; i < this.Count; i++)
			{
				sb.Append(array[i]);
				sb.Append(", ");
			}
			string result = sb.ToString().TrimEnd(' ', ',');
			result += "]";
			return result;
		}
	}
}
