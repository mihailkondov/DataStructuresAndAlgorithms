using DataStructures.Trees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Demos.TreeDemos
{
	public class BasicTreeDemo : IDemo
	{
		public void Run()
		{
			BasicTree<int> tree =
				new BasicTree<int>(7,
					new BasicTree<int>(19,
						new BasicTree<int>(1),
						new BasicTree<int>(12),
						new BasicTree<int>(31)),
					new BasicTree<int>(21),
					new BasicTree<int>(14,
						new BasicTree<int>(23),
						new BasicTree<int>(6))
			);

			tree.Print();
			Console.WriteLine("Custom DFS function -> Pre order");
			tree.ApplyVoidFunctionDepthFirstPreOrder(Console.WriteLine);

			Console.WriteLine("Custom DFS function -> Post order");
			tree.ApplyVoidFunctionDepthFirstPostOrder(Console.WriteLine);

			Console.WriteLine("Custom DFS function -> In order");
			tree.ApplyVoidFunctionDepthFirstInOrder(Console.WriteLine);

            Console.WriteLine("Print members bredth first:");
			tree.ApplyVoidFunctionBreadthFirst(Console.WriteLine);
        }
	}
}
