using LinearDataStructures.Stack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.StackTests
{
    internal class TestStackStatic
    {
        StackStatic<int> stack;
        [SetUp]
        public void Setup()
        {
            stack = new StackStatic<int>([1, 2, 3, 4]);
        }

        [Test]
        public void Push()
        {
            StackStatic<int> constructor1Test = new StackStatic<int>();
            Assert.That(constructor1Test != null);
            Assert.That(constructor1Test.Count == 0);

            StackStatic<int> constructor2Test = new StackStatic<int>(1);
            Assert.That(constructor2Test != null);
            Assert.That(constructor2Test.Peek() == 1);
            Assert.That(constructor2Test.Count == 1);

            StackStatic<int> constructor3Test = new StackStatic<int>([1, 2, 3, 4]);
            Assert.That(constructor3Test.Count == 4);

            StackStatic<int> pushTest = new StackStatic<int>();
            pushTest.Push(1);
            Assert.That(pushTest.Count == 1);
            Assert.That(pushTest.Peek() == 1);

            pushTest.Push(2);
            Assert.That(pushTest.Count == 2);
            Assert.That(pushTest.Peek() == 2);


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
