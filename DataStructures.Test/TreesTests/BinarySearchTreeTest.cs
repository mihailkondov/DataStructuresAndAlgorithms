using DataStructures.Trees;
using static DataStructures.Tests.TreesTests.TreesTestsConstants;
using static DataStructures.Trees.TreeErrorMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tests.TreesTests
{
	public class BinarySearchTreeTest
	{
		BinarySearchTree tree;
		const int NUMBER_FOUND = 8;
		const int NUMBER_NOT_FOUND = 1300;

		[SetUp]
		public void SetUp()
		{
			tree = new BinarySearchTree(NUMBERS[0]);
			for (int i = 1; i < NUMBERS.Length; i++)
			{
				tree.AddTree(new BinarySearchTree(NUMBERS[i]));
			}

		}

		#region Search functionality
		[Test]
		public void SearchFound()
		{
			BinarySearchTree result;

			result = tree.Search(NUMBERS[0]);
			Assert.That(result, Is.EqualTo(tree));

			result = tree.Search(NUMBER_FOUND);
			Assert.That(result.Value, Is.EqualTo(NUMBER_FOUND));
		}

		[Test]
		public void SearchNotFound()
		{
			BinarySearchTree result;
			result = tree.Search(NUMBER_NOT_FOUND);

			Assert.That(result, Is.Null);
		}

		[TestCase(1)]
		[TestCase(2)]
		[TestCase(5)]
		[TestCase(9)]
		public void DFSFound(int testNumber)
		{
			BinarySearchTree result;

			result = tree.DFS(testNumber);
			if(testNumber == 5)
			{
				Assert.That(result, Is.EqualTo(tree));
			}

			result = tree.DFS(testNumber);
			Assert.That(result.Value, Is.EqualTo(testNumber));
		}

		
		[Test]
		public void DFSNotFound()
		{

			BinarySearchTree result;
			result = tree.DFS(NUMBER_NOT_FOUND);

			Assert.That(result, Is.Null);
		}


		[TestCase(1)]
		[TestCase(2)]
		[TestCase(5)]
		[TestCase(9)]
		public void BFSFound(int testNumber)
		{
			BinarySearchTree result;

			result = tree.BFS(testNumber);
			if (testNumber == 5)
			{
				Assert.That(result, Is.EqualTo(tree));
			}

			result = tree.BFS(testNumber);
			Assert.That(result.Value, Is.EqualTo(testNumber));
		}


		[Test]
		public void BFSNotFound()
		{

			BinarySearchTree result;
			result = tree.BFS(NUMBER_NOT_FOUND);

			Assert.That(result, Is.Null);
		}

		#endregion

		#region Comparison functionality
		[Test]
		public void AreTreesIdentical()
		{
			Assert.That(BinarySearchTree.AreTreesIdentical(null, null), Is.True);
			Assert.That(BinarySearchTree.AreTreesIdentical(tree, tree), Is.True);
			Assert.That(BinarySearchTree.AreTreesIdentical(tree, new BinarySearchTree(NUMBERS[0])), Is.False);
			Assert.That(BinarySearchTree.AreTreesIdentical(new BinarySearchTree(NUMBERS[0]), new BinarySearchTree(NUMBERS[0])), Is.True);

		}


		#endregion

		#region Adding nodes and values

		[Test]
		public void AddChild()
		{
			Assert.DoesNotThrow(() => tree.AddTree(null));
		}

		[Test]
		public void AddValue()
		{
			BinarySearchTree newTree = new BinarySearchTree(NUMBERS[0]);
			for (int i = 1; i < NUMBERS.Length; i++)
			{
				newTree.AddValue(NUMBERS[i]);
			}

			Assert.That(tree.Value, Is.EqualTo(newTree.Value));
			Assert.That(BinarySearchTree.AreTreesIdentical(tree, newTree), Is.True);

		}

		#endregion

		#region Removing nodes and values
		[Test]
		public void RemoveChild()
		{
			tree.RemoveNode(9);
			Assert.That(tree.Children[1].Value, Is.EqualTo(7));

			SetUp();
			tree.RemoveNode(2);
			Assert.That(tree.Children[0].Value, Is.EqualTo(1));
			Assert.That(tree.Children[0].Children[1].Value, Is.EqualTo(3));

			SetUp();
			//Cleaning up the whole tree:
			for (int i = 0; i < NUMBERS.Length - 1; i++)
			{
				tree.RemoveNode(NUMBERS[i]);
			}
			Assert.That(tree.Value, Is.EqualTo(NUMBERS[NUMBERS.Length - 1]));
			Assert.That(tree.Children[0], Is.Null);
			Assert.That(tree.Children[1], Is.Null);
			Assert.Throws<ArgumentException>(
				() => { tree.RemoveNode(NUMBERS[NUMBERS.Length - 1]); },
				TREE_DELETE_LAST_MEMBER
			);

			SetUp();
			//Cleaning up the whole tree in a different order:
			for (int i = 0; i < NUMBERS_REORDERED.Length - 1; i++)
			{
				tree.RemoveNode(NUMBERS_REORDERED[i]);
			}
			Assert.That(tree.Value, Is.EqualTo(NUMBERS_REORDERED[NUMBERS_REORDERED.Length - 1]));
			Assert.That(tree.Children[0], Is.Null);
			Assert.That(tree.Children[1], Is.Null);

			Assert.Throws<ArgumentException>(
				() => { tree.RemoveNode(NUMBERS_REORDERED[NUMBERS_REORDERED.Length - 1]); },
				TREE_DELETE_LAST_MEMBER
			);
		}
		#endregion
	}
}
