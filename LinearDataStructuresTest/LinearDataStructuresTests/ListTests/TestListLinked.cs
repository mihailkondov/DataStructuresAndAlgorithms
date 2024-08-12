using LinearDataStructures.LinearDataStructures.Lists.LinkedList;

namespace Tests.LinearDataStructuresTests.ListTests
{
    internal class TestListLinked
    {
        ListLinked<int> listInt;
        ListLinked<int> listEmpty;
        int[] integers = [1, 2, 3, 4, 5, 6, 7, 8];
        [SetUp]
        public void Setup()
        {
            listInt = new ListLinked<int>();
            for (int i = 0; i < integers.Length; i++)
            {
                listInt.Add(integers[i]);
            }

            listEmpty = new ListLinked<int>();
        }

        [Test]
        public void Initial()
        {
            Assert.That(listInt != null);
            Assert.That(listInt.Count == 8);
        }

        [Test]
        public void Add()
        {
            ListLinked<int> list = new ListLinked<int>();
            ListLinked<string> listS = new ListLinked<string>();
            list.Add(1);
            Assert.DoesNotThrow(() => list.Add(1));
            Assert.That(list.Head.Data == 1);
            listS.Add("Hi");
            Assert.That(listS.Head.Data.Equals("Hi"));

        }

        [Test]
        public void Delete()
        {
            int count = listInt.Count;
            Assert.That(count == integers.Length);
            listInt.Delete(1);
            Assert.That(listInt.Head.Data == 2);
            Assert.That(listInt.Count == integers.Length - 1);
            listInt.Delete(3);
            Assert.That(listInt.Head.Next.Data == 4);
            listInt.Delete(2);
            listInt.Delete(4);
            listInt.Delete(5);
            listInt.Delete(6);
            listInt.Delete(7);
            listInt.Delete(8);
            Assert.That(listInt.Head == null);
            Assert.That(listInt.Count == 0);
        }

        [Test]
        public void Clear()
        {
            listInt.Clear();
            Assert.That(listInt.Head == null);
            Assert.That(listInt.Count == 0);
        }

        [Test]
        public void Reverse()
        {
            int last = integers[integers.Length - 1];
            listInt.Reverse();
            Assert.That(listInt.Head.Data == last);

            int[] placeholder = new int[integers.Length];
            int index = 0;
            ListLinkedNode<int> current = listInt.Head;
            while (current != null)
            {
                placeholder[index] = current.Data;
                index++;
                current = current.Next;
            }

            Assert.That(placeholder.Reverse().SequenceEqual(integers));
        }

        [Test]
        public void Search()
        {
            Assert.That(listInt.Search(2) == 1);
            Assert.That(listInt.Search(1465278) == -1);
        }

        [Test]
        public void Insert()
        {
            listInt.Insert(0, 200);
            Assert.That(listInt.Head.Data == 200);
        }

        [Test]
        public void Enumerator()
        {
            Assert.That(listInt[0] == integers[0]);
            Assert.That(listInt[listInt.Count - 1] == integers[integers.Length - 1]);

            Assert.Throws<IndexOutOfRangeException>(() => { var value = listInt[-1]; }, "Index cannot be negative");

            Assert.Throws<IndexOutOfRangeException>(() => { var value = listInt[listInt.Count]; }, "Index out of range");
        }

        [Test]
        public void AddLast()
        {
            listEmpty.AddLast(100);
            Assert.That(listEmpty.Count == 1);
            Assert.That(listEmpty.Head.Data == 100);

            listEmpty.AddLast(200);
            Assert.That(listEmpty.Count == 2);
            Assert.That(listEmpty.Head.Next.Data == 200);

            listInt.AddLast(1337);
            Assert.That(listInt[8] == 1337);
            Assert.That(listInt.Count == 9);
        }

        [Test]
        public void AddFirst()
        {
            listEmpty.AddFirst(123);
            Assert.That(listEmpty.Head.Data == 123);

            listEmpty.AddFirst(3210);
            Assert.That(listEmpty.Head.Data == 3210);
        }

        [Test]
        public void AddBefore()
        {
            listInt.AddBefore(3, 999);
            Assert.That(listInt.Count == 9);
            Assert.That(listInt.Head.Next.Next.Data == 999);
            Assert.That(listInt.Head.Next.Next.Next.Data == 3);
        }

        [Test]
        public void AddAfter()
        {
            listInt.AddAfter(2, 999);
            Assert.That(listInt.Count == 9);
            Assert.That(listInt.Head.Next.Data == 2);
            Assert.That(listInt.Head.Next.Next.Data == 999);
            Assert.That(listInt.Head.Next.Next.Next.Data == 3);
        }
    }
}
