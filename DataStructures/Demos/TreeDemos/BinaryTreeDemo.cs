using DataStructures.Trees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Demos.TreeDemos
{
	internal class BinaryTreeDemo : IDemo
	{
		public void Run()
		{
			int numberNotFound = 1203;
			int[] numbers = new int[] { 5, 9, 2, 7, 3, 8, 1, 14, 4, 19 };
			BinarySearchTree tree = new BinarySearchTree(numbers[0]);
			for (int i = 1; i < numbers.Length; i++)
			{
				tree.AddChild(new BinarySearchTree(numbers[i]));
			}

			tree.Print();
			Console.WriteLine($"Searching for {numbers[5]}");
			BinarySearchTree treeFound = tree.Search(numbers[5]);
			treeFound.Print();
            Console.WriteLine(treeFound);
            Console.WriteLine($"Searching for {numberNotFound}");
			BinarySearchTree treeNotFound = tree.Search(numberNotFound);
            if(treeNotFound == null)
			{
                Console.WriteLine($"tree.Search({numberNotFound}) returned null.");
			}
			else
			{
			Console.WriteLine("SOMETHING WENT WRONG");
			}
        }
	}
}
