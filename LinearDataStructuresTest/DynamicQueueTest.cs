using LinearDataStructures.Queue;

namespace Tests
{
	internal class DynamicQueueTest
	{
		DynamicQueue<int> queue;
		DynamicQueue<int> queueOne;
		[SetUp]
		public void SetUp() 
		{
			queue = new DynamicQueue<int>();
			queueOne = new DynamicQueue<int>(100);
		}

		[Test]
		public void Constructors()
		{
			DynamicQueue<int> queue1 = new DynamicQueue<int>();
			Assert.That(queue1 != null);
			Assert.That(queue1.Count == 0);

			DynamicQueue<int> queue2 = new DynamicQueue<int>(1);
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
	}
}
