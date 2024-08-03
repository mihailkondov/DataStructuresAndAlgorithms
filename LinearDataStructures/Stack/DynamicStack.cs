using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearDataStructures.Stack
{
	public class DynamicStack<T> : IStack<T>
	{

        public DynamicStack()
        {
            Count = 0;
        }

        public DynamicStack(T data)
        {
			Push(data);
        }

		public DynamicStack(T[] dataArray)
		{
			for(int i = 0; i<dataArray.Length; i++)
			{
				Push(dataArray[i]);
			}
		}

		public DynamicStackNode<T>? Top { get; private set; } = null;
        public int Count { get; private set; }

        public T Peek()
		{
			if (Top == null) throw new InvalidOperationException("Stack is empty");

			return Top.Data;
		}

		public T Pop()
		{
			if (Top == null) throw new InvalidOperationException("Stack is empty");

			T data = Top.Data;
			if(Top.Next != null)
				Top = Top.Next;
			Count--;
			return data;
		}

		public void Push(T data)
		{
			DynamicStackNode<T> newNode = new DynamicStackNode<T>(data);
			newNode.Next = Top;
			Top = newNode;
			Count++;
		}
	}
}
