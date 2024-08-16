using System;
using System.Collections.Generic;
using System.ComponentModel;
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
			if (tree == null)
				return;

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

		public void RemoveChild(int number)
		{
			BinarySearchTree parent = this;
			BinarySearchTree current;

			if (Value == number) // this is a special case where I can't refer to the parent
			{
				if (Children[0] == null && Children[1] == null) //only 1 node in the tree
				{
					Value = 0;
					return;										  
				}												  
				else											  
				{
					//Default case: left branch becomes root
					//Check if left branch is null: can't accesss the value -> right branch becomes the main one
					if (Children[0] == null) // only left branch					  
					{											  
						Value = Children[1].Value;				  
						Children[0] = Children[1].Children[0]; //0 is first since 1 needs to be accessed again
						Children[1] = Children[1].Children[1]; 	  
						return;
					}											  
					else //Default case where left branch becomes the root
					{
						BinarySearchTree rightBranch = Children[1];
						Value = Children[0].Value;
						Children[1] = Children[0].Children[1]; // 1 is first since 0 needs to be accesessed again
						Children[0] = Children[0].Children[0];
						if(rightBranch != null)
						{
							AddChild(rightBranch);
						}
						return;
					}
				}
			}
			else
			{
				if(number < Value)
				{
					current = Children[0];
				}
				else
				{
					current = Children[1];
				}
			}

			//If I am here then I am not working on the root.

			while (current != null)
			{
				if (current.Value == number)
				{
					BinarySearchTree child0 = current.Children[0];
					BinarySearchTree child1 = current.Children[1];

					if(number < parent.Value) //Deleting the node
					{
						parent.Children[0] = null;
					}
					else
					{
						parent.Children[1] = null;
					}

					if(child0 != null) //Restoring the children of the deleted node
					{
						this.AddChild(child0);
					}
					if(child1 != null)
					{
						this.AddChild(child1);
					}

					return;
				}
				else if (number < current.Value)
				{
					parent=current;
					current = current.Children[0];
				}
				else
				{
					parent = current;
					current = current.Children[1];
				}
			}
			throw new WarningException("Item not found");
		}

		public void Print(string space = "")
		{
			if (this == null)
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
