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
			int[] numbers = new int[] { 5, 9, 2, 7, 3, 8, 1, 14, 4, 19 };
			BinarySearchTree tree = new BinarySearchTree(numbers[0]);
			for(int i = 1; i < numbers.Length; i++)
			{
				tree.AddChild(new BinarySearchTree(numbers[i]));
			}

			tree.Print();
		}
	}
}
