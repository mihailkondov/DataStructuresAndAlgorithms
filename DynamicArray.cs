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
		public void Delete(object data) { }
		public int Search(object data) 
		{
			throw new NotImplementedException();
		}
		private void Grow() { }
		private void Shrink() { }
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
