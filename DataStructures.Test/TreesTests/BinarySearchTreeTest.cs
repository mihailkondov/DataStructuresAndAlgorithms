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
				tree.AddChild(new BinarySearchTree(NUMBERS[i]));
			}

		}

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

		[Test]
		public void AddChild()
		{
			Assert.DoesNotThrow(() => tree.AddChild(null));
		}

		[Test]
		public void RemoveChild()
		{
			tree.RemoveChild(9);
			Assert.That(tree.Children[1].Value, Is.EqualTo(7));

			SetUp();
			tree.RemoveChild(2);
			Assert.That(tree.Children[0].Value, Is.EqualTo(1));
			Assert.That(tree.Children[0].Children[1].Value, Is.EqualTo(3));

			SetUp();
			//Cleaning up the whole tree:
			for (int i = 0; i < NUMBERS.Length - 1; i++)
			{
				tree.RemoveChild(NUMBERS[i]);
			}
			Assert.That(tree.Value, Is.EqualTo(NUMBERS[NUMBERS.Length - 1]));
			Assert.That(tree.Children[0], Is.Null);
			Assert.That(tree.Children[1], Is.Null);
			Assert.Throws<ArgumentException>(
				() => { tree.RemoveChild(NUMBERS[NUMBERS.Length - 1]); },
				TREE_DELETE_LAST_MEMBER
);
			SetUp();
			//Cleaning up the whole tree in a different order:
			for (int i = 0; i < NUMBERS_REORDERED.Length - 1; i++)
			{
				tree.RemoveChild(NUMBERS_REORDERED[i]);
			}
			Assert.That(tree.Value, Is.EqualTo(NUMBERS_REORDERED[NUMBERS_REORDERED.Length - 1]));
			Assert.That(tree.Children[0], Is.Null);
			Assert.That(tree.Children[1], Is.Null);

			Assert.Throws<ArgumentException>(
				() => { tree.RemoveChild(NUMBERS_REORDERED[NUMBERS_REORDERED.Length - 1]); },
				TREE_DELETE_LAST_MEMBER
			);
		}
	}
}
