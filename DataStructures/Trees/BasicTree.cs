using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataStructures.Trees
{
	public class BasicTree<T>
	{
		private BasicTreeNode<T> _root;


		public BasicTree(T value, params BasicTree<T>[] children)
		{
			_root = new BasicTreeNode<T>(value);

			foreach (var child in children)
			{
				_root.AddChild(child.Root);
			}
		}

		public BasicTreeNode<T> Root { get => _root; set => _root = value; }


		public void Print()
		{
			Console.WriteLine("Printing Tree:");
			_root.Print();
		}


		public delegate void NodeVoidType(T value);
		public delegate void NodeVoidTree(BasicTree<T> value);

		public void ApplyVoidFunctionDepthFirstPreOrder(NodeVoidType function)
		{
			function(Root.Value);

			foreach (BasicTreeNode<T> node in _root.Children)
			{
				node.GetTree.ApplyVoidFunctionDepthFirstPreOrder(function);
			}
		}

		public void ApplyVoidFunctionDepthFirstPostOrder(NodeVoidType function)
		{

			foreach (BasicTreeNode<T> node in _root.Children)
			{
				node.GetTree.ApplyVoidFunctionDepthFirstPostOrder(function);
			}

			function(Root.Value);

		}

		public void ApplyVoidFunctionDepthFirstInOrder(NodeVoidType function, int depth = 0)
		{
			depth++;
			string buffer = "";
			for(int j = 0; j < depth; j++)
			{
				buffer += "   ";
			}
			if (_root.Children.Count > 1)
			{
                _root.Children[0].GetTree.ApplyVoidFunctionDepthFirstInOrder(function, depth);

				Console.Write(buffer);
				function(Root.Value);

				for (int i = 1; i < _root.Children.Count; i++)
				{
					_root.Children[i].GetTree.ApplyVoidFunctionDepthFirstInOrder(function, depth);
				}
			}
			else
			{

				Console.Write(buffer);
				function(Root.Value);

				foreach (var child in _root.Children)
				{
					child.GetTree.ApplyVoidFunctionDepthFirstInOrder(function, depth);
				}
			}
		}
		public void ApplyVoidFunctionBreadthFirst(NodeVoidType function, bool first = true)
		{
			if(first)
			{
				function(this.Root.Value);
			}

			foreach(var child in Root.Children)
			{
				function(child.Value);
			}

			foreach(var child in _root.Children)
			{
				child.GetTree.ApplyVoidFunctionBreadthFirst(function, false);
			}
		}
	}
}
