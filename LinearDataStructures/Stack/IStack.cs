using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearDataStructures.Stack
{
	public interface IStack<T>
	{
		T Peek();
		T Pop();
		void Push(T data);
	}
}
