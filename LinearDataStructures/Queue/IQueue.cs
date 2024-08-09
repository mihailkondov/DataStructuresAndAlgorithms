using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearDataStructures.Queue
{
	internal interface IQueue<T>
	{
		void Enqueue(T data);
		T Dequeue();
		T Peek();
	}
}
