using LinearDataStructures.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
	public class TestQueueStatic
	{
		string[] strings;
		int[] ints;
		QueueStatic<int> queueInt;
		QueueStatic<string> queueString;

		[SetUp]
		public void SetUp()
		{
			queueInt = new QueueStatic<int>();
			queueString = new QueueStatic<string>();
			ints = new int[] { 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000, 1100, 1200, 1300, 1400, 1500, 1600 };
			strings = new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen" };
		}

		[Test]
		public void EnqueueInt()
		{
			foreach (var item in ints)
			{
				queueInt.Enqueue(item);
			}

			Assert.That(queueInt.Count == ints.Length);
		}

		[Test]
		public void EnqueueString()
		{
			foreach (var item in strings)
			{
				queueString.Enqueue(item);
			}

			Assert.That(queueString.Count == strings.Length);
		}

		[Test]
		public void PeekInt()
		{
			int test = 100;
			queueInt.Enqueue(test);
			int result = queueInt.Peek();
			Assert.That(result.Equals(test));
			Assert.That(queueInt.Count == 1);

			queueInt.Enqueue(200);
			Assert.That(queueInt.Peek() == test);
			Assert.That(queueInt.Count == 2);
		}

		[Test]
		public void PeekString()
		{
			string str = "test";

			Assert.Throws<InvalidOperationException>(
				() => { var a = queueString.Peek(); },
				"Queue is empty. Can only peek in a queue with 1 or more members");

			queueString.Enqueue(str);
			string result = queueString.Peek();
			Assert.That(result.Equals(str));
			Assert.That(queueString.Count == 1);

			queueString.Enqueue("secondInLine");
			Assert.That(queueString.Peek() == str);
			Assert.That(queueString.Count == 2);

		}

		[Test]
		public void DequeueInt()
		{
			//Arrange
			int[] resultArray = new int[16];

			foreach (var item in ints)
			{
				queueInt.Enqueue(item);
			}

			//Act
			for (int i = 0; i < ints.Length; i++)
			{
				resultArray[i] = queueInt.Dequeue();
			}

			//Assert
			Assert.That(resultArray.SequenceEqual(ints));
			Assert.That(queueInt.Count == 0);
			Assert.Throws<InvalidOperationException>(() => queueInt.Dequeue(), "Cannot dequeue from an empty queue.");

		}

		[Test]
		public void DequeueString()
		{
			// Arrange
			string[] resultArray = new string[16];

			foreach (var item in strings)
			{
				queueString.Enqueue(item);
			}

			// Act
			for (int i = 0; i < resultArray.Length; i++)
			{
				resultArray[i] = queueString.Dequeue();
			}

			// Assert
			Assert.That(EqualsCompareStringArraysByValue(resultArray, strings));
			Assert.That(queueString.Count == 0);
			Assert.Throws<InvalidOperationException>(() => queueString.Dequeue(), "Cannot dequeue from an empty queue.");
		}

		[Test]
		public void RotatingHead()
		{
			for (int j = 0; j < 5; j++) // 2 Grow (capacity 8)
			{
				queueInt.Enqueue(ints[j]);
			}

			int[] result = new int[ints.Length];
			int i = 0;
			while (i < result.Length)
			{
				if (5 + i < ints.Length)
				{
					queueInt.Enqueue(ints[5 + i]);
				}
				result[i++] = queueInt.Dequeue();
			}

			Assert.That(result.SequenceEqual(ints));

		}

		/// <summary>
		/// Compares two arrays of strings character by character for each string. 
		/// </summary>
		/// <param name="a">string array to compare</param>
		/// <param name="b">string array to compare</param>
		/// <returns></returns>
		private bool EqualsCompareStringArraysByValue(string[] a, string[] b)
		{
			if (a.Length != b.Length)
			{
				return false;
			}

			for (int i = 0; i < a.Length; i++)
			{
				if (string.Compare(a[i], b[i]) != 0)
				{
					return false;
				}
			}

			return true;
		}
	}
}
