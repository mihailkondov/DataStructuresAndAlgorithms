using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
	[DebuggerDisplay("Value: {Value}, Children Count: {Children.Count}")]
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
			if (newValue >= Value)
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

		public void Print(string space = "")
		{
			if(space == "")
			{
                Console.WriteLine(Value);
            }

			space += "  ";
			foreach (var node in Children)
			{
				if(node == null)
				{
					continue;
				}
				Console.WriteLine(space + node.Value);
				node.Print(space);
			}
		}

	}
}
