using LinearDataStructures.Queue;
using Microsoft.VisualBasic;

namespace Tests
{
	internal class TestQueueDynamic : TestQueueCommonMethods
	{
		QueueDynamic<int> queue;
		QueueDynamic<int> queueOne;
		QueueDynamic<int> queueInt;
		QueueDynamic<string> queueStr;
		int[] ints;
		string[] strings;

		[SetUp]
		public void SetUp() 
		{
			queue = new QueueDynamic<int>();
			queueOne = new QueueDynamic<int>(100);
			queueInt = new QueueDynamic<int>();
			queueStr = new QueueDynamic<string>();

			ints = new int[] { 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000, 1100, 1200, 1300, 1400, 1500, 1600 };
			strings = new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen" };
		}

		[Test]
		public void Constructors()
		{
			QueueDynamic<int> queue1 = new QueueDynamic<int>();
			Assert.That(queue1 != null);
			Assert.That(queue1.Count == 0);

			QueueDynamic<int> queue2 = new QueueDynamic<int>(1);
			Assert.That(queue2 != null);
			Assert.That(queue2.Count == 1);
		}

		[Test]
		public void Enqueue() 
		{
			queue.Enqueue(100);
			Assert.That(queue.Count == 1);
		}

		[Test]
		public void Peek()
		{
			queue.Enqueue(100);
			int peekValue = queue.Peek();
			int sameValue = queue.Peek();
			Assert.That(queue.Peek() == 100);
			Assert.That(peekValue == 100);
			Assert.That(sameValue == 100);
		}

		[Test]
		public void Dequeue()
		{
			int a = queueOne.Dequeue();
			Assert.That(a ==  100);

			queueOne.Enqueue(100);
			queueOne.Enqueue(200);
			queueOne.Enqueue(300);

			a = queueOne.Dequeue();
			Assert.That(a == 100);

			a = queueOne.Dequeue();
			Assert.That(a == 200);

			a = queueOne.Dequeue();
			Assert.That(a == 300);

			Assert.Throws<InvalidOperationException>(
				() => { var b = queueOne.Dequeue(); }, "Queue is empty");


		}

		[Test]
		public void Count()
		{
			Assert.That(queue.Count == 0);
			Assert.That(queueOne.Count == 1);

			queue.Enqueue(100);
			Assert.That(queue.Count == 1);
			queue.Enqueue(200);
			Assert.That(queue.Count == 2);
			queue.Enqueue(300);
			Assert.That(queue.Count == 3);

			queue.Peek();
			Assert.That(queue.Count == 3);

			queue.Dequeue();
			Assert.That(queue.Count == 2);

			queue.Dequeue();
			Assert.That(queue.Count == 1);

			queue.Dequeue();
			Assert.That(queue.Count == 0);
		}

		[Test]
		public void Clear()
		{

			foreach (var item in ints)
			{
				queueInt.Enqueue(item);
			}

			foreach (var item in strings)
			{
				queueStr.Enqueue(item);
			}

			queueInt.Clear();
			queueStr.Clear();
			Assert.That(queueInt.Count, Is.EqualTo(0));
			Assert.That(queueStr.Count, Is.EqualTo(0));

		}

		[Test]
		public void ClearEmpty()
		{
			queueInt.Clear();
			queueStr.Clear();
			Assert.That(queueInt.Count, Is.EqualTo(0));
			Assert.That(queueStr.Count, Is.EqualTo(0));
		}

		[TestCase(100)]
		[TestCase(200)]
		[TestCase(300)]
		[TestCase(400)]
		[TestCase(500)]
		[TestCase(600)]
		[TestCase(1600)]
		public void ContainsFoundInt(int a)
		{
			foreach (var item in ints)
			{
				queueInt.Enqueue(item);
			}
			Assert.That(queueInt.Contains(a) == true);
		}

		[Test]
		public void ContainsNotFoundInt()
		{
			Assert.That(queueInt.Contains(53478) == false);

			foreach (var item in ints)
			{
				queueInt.Enqueue(item);
			}

			Assert.That(queueInt.Contains(53478) == false);

		}

		[TestCase("one")]
		[TestCase("two")]
		[TestCase("three")]
		[TestCase("seven")]
		[TestCase("eight")]
		[TestCase("fourteen")]
		[TestCase("sixteen")]
		public void ContainsFoundStr(string a)
		{
			foreach (var item in strings)
			{
				queueStr.Enqueue(item);
			}
			Assert.That(queueStr.Contains(a) == true);
		}

		[Test]
		public void ContainsNotFoundStr()
		{
			Assert.That(queueStr.Contains("53478") == false);

			foreach (var item in strings)
			{
				queueStr.Enqueue(item);
			}

			Assert.That(queueStr.Contains("53478") == false);
		}

		[Test]
		public void ToArrayInt()
		{
			foreach (var item in ints)
			{
				queueInt.Enqueue(item);
			}

			Assert.That(queueInt.ToArray().SequenceEqual(ints));
		}

		[Test]
		public void ToArrayString()
		{
			foreach (var item in strings)
			{
				queueStr.Enqueue(item);
			}

			Assert.That(EqualsCompareStringArraysByValue(strings, queueStr.ToArray()));
		}
	}
}
