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

		public void add(object data) 
		{ 
			if(this.Count >= capacity)
			{
				this.grow();
			}
			array[Count] = data;
			this.Count++;
		}
		public void insert(int  index, object data) 
		{
			
		} 
		public void delete(object data) { }
		public int search(object data) 
		{
			throw new NotImplementedException();
		}
		private void grow() { }
		private void shrink() { }
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
