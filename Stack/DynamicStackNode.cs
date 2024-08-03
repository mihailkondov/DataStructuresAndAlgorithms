using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearDataStructures.Stack
{
	public class DynamicStackNode<T>(T data)
	{
		public DynamicStackNode<T> ?Next = null;
		public T Data = data;
	}
}
