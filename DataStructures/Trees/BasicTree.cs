using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
	public class BasicTree<T>
	{
		private BasicTreeNode<T> _root;

		public BasicTree(T value, params BasicTree<T>[] children)
		{
			_root = new BasicTreeNode<T>(value);

			foreach(var child in children)
			{
				_root.AddChild(child.Root);
			}
		}

        public BasicTreeNode<T> Root { get => _root; }

		public void Print()
		{
            Console.WriteLine("Printing Tree:");
            _root.Print();
		}
    }
}
