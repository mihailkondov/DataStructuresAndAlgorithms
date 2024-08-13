using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
	public class BasicTreeNode<T>
	{

		private T _value;
		private List<BasicTreeNode<T>> _children;

		public BasicTreeNode(T data) 
		{
			_value = data;
			_children = new List<BasicTreeNode<T>>();
		}

		public void AddChild(BasicTreeNode<T> data)
		{
			_children.Add(data);
		}

		public BasicTreeNode<T> GetChild(int index)
		{
			return _children[index];
		}

        public List<BasicTreeNode<T>> Children { get => _children; set => _children = value; }
        public T Value { get => _value; set => _value = value; }

        public int Count { get => _children.Count; }

		public void Print(string indent = "")
		{
			indent += "  ";
            Console.WriteLine(indent + Value);
			foreach(var child in  Children)
			{
				child.Print(indent);
			}
        }

    }
}
