using DataStructures.Trees;
using static DataStructures.Tests.TreesTests.TreesTestsConstants;
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
			foreach(int  i in NUMBERS)
			{
				tree.RemoveChild(i);
			}
			Assert.That(tree.Value, Is.EqualTo(0));
			Assert.That(tree.Children[0], Is.Null);
			Assert.That(tree.Children[1], Is.Null);

			SetUp();
			//Cleaning up the whole tree in a different order:
			foreach (int i in NUMBERS_REORDERD)
			{
				tree.RemoveChild(i);
			}
			Assert.That(tree.Value, Is.EqualTo(0));
			Assert.That(tree.Children[0], Is.Null);
			Assert.That(tree.Children[1], Is.Null);

		}
	}
}
