using LinearDataStructures.Queue;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tests.QueueTests
{
    public class TestQueueStatic : TestQueueCommonMethods
    {
        string[] strings;
        int[] ints;
        QueueStatic<int> queueInt;
        QueueStatic<string> queueStr;

        [SetUp]
        public void SetUp()
        {
            queueInt = new QueueStatic<int>();
            queueStr = new QueueStatic<string>();
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
                queueStr.Enqueue(item);
            }

            Assert.That(queueStr.Count == strings.Length);
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
                () => { var a = queueStr.Peek(); },
                "Queue is empty. Can only peek in a queue with 1 or more members");

            queueStr.Enqueue(str);
            string result = queueStr.Peek();
            Assert.That(result.Equals(str));
            Assert.That(queueStr.Count == 1);

            queueStr.Enqueue("secondInLine");
            Assert.That(queueStr.Peek() == str);
            Assert.That(queueStr.Count == 2);

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
                queueStr.Enqueue(item);
            }

            // Act
            for (int i = 0; i < resultArray.Length; i++)
            {
                resultArray[i] = queueStr.Dequeue();
            }

            // Assert
            Assert.That(EqualsCompareStringArraysByValue(resultArray, strings));
            Assert.That(queueStr.Count == 0);
            Assert.Throws<InvalidOperationException>(() => queueStr.Dequeue(), "Cannot dequeue from an empty queue.");
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

        [Test]
        public void TrimExcess()
        {
            int elementsToMove = 12;
            for (int i = 0; i < elementsToMove; i++)
            {
                queueStr.Enqueue(strings[i]);
            }

            queueStr.TrimExcess();

            Assert.That(queueStr.Count == elementsToMove);
            Assert.DoesNotThrow(() => queueStr.TrimExcess());
            Assert.That(queueStr.Capacity == elementsToMove);

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
    }
}
