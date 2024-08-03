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
		DynamicStackNode<T> ?Top = null;

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
			return data;
		}

		public void Push(T data)
		{
			DynamicStackNode<T> newNode = new DynamicStackNode<T>(data);
			newNode.Next = Top;
			Top = newNode;
		}
	}
}
