using LinearDataStructures.Stack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
	public class DynamicStackTest
	{
		DynamicStack<int> stack;
		[SetUp]
		public void Setup() 
		{
			stack = new DynamicStack<int> ([1, 2, 3, 4]);

		}

		[Test]
		public void Push() 
		{
			DynamicStack<int> constructor1Test = new DynamicStack<int> ();
			Assert.That(constructor1Test != null);
			Assert.That(constructor1Test.Count == 0);

			DynamicStack<int> constructor2Test = new DynamicStack<int>(1);
			Assert.That(constructor2Test != null);
			Assert.That(constructor2Test.Top != null);
			Assert.That(constructor2Test.Top.Data == 1);
			Assert.That(constructor2Test.Count == 1);

			DynamicStack<int> constructor3Test = new DynamicStack<int>([1, 2, 3, 4]);
			Assert.That(constructor3Test.Count == 4);

			DynamicStack<int> pushTest = new DynamicStack<int>();
			pushTest.Push(1);
			Assert.That (pushTest.Count == 1);
			Assert.That(pushTest.Top.Data == 1);

			pushTest.Push(2);
			Assert.That(pushTest.Count == 2);
			Assert.That(pushTest.Top.Data == 2);


		}

		[Test]
		public void Pop()
		{
			int top = stack.Pop();
			Assert.That(top == 4);
			Assert.That(stack.Count == 3);
		}

		[Test]
		public void Peek()
		{
			int top = stack.Peek();
			Assert.That(top == 4);
			Assert.That(stack.Count == 4);
		}
	}
}
