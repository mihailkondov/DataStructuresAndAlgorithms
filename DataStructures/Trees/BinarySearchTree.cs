using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
	[DebuggerDisplay("Value: {Value}, ({Children[0].Value}, {Children[1].Value})")]
	public class BinarySearchTree
	{
		public BinarySearchTree(int data)
		{
			Value = data;
		}

		public BinarySearchTree[] Children { get; private set; } = new BinarySearchTree[2];

		public int Value { get; set; }

		public void AddChild(BinarySearchTree tree)
		{
			int newValue = tree.Value;
			if (newValue < Value)
			{
				if (Children[0] == null)
				{
					Children[0] = tree;
				}
				else
				{
					Children[0].AddChild(tree);
				}
			}
			else
			{
				if (Children[1] == null)
				{
					Children[1] = tree;
				}
				else
				{
					Children[1].AddChild(tree);
				}
			}
		}

		public BinarySearchTree Search(int data)
		{

			if (data == this.Value)
			{
				return this;
			}
			else if (data < this.Value)
			{
				if (Children[0] == null)
				{
					return null;
				}
				else
				{
					return this.Children[0].Search(data);
				}
			}
			else
			{
				if (Children[1] == null)
				{
					return null;
				}
				return this.Children[1].Search(data);
			}
		}

		public void RemoveChild(BinarySearchTree tree)
		{
			throw new NotImplementedException();

		}

		public void Print(string space = "")
		{
			if(this == null)
			{
                Console.WriteLine("null");
				return;
            }
			if (space == "")
			{
				Console.WriteLine(Value);
			}

			space += "  ";
			foreach (var node in Children)
			{
				if (node == null)
				{
					continue;
				}
				node.Print(space);
				Console.WriteLine(space + node.Value);
			}
		}
	}
}
