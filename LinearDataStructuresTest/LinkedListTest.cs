using LinearDataStructures.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
	internal class LinkedListTest
	{
		LinearDataStructures.LinkedList<int> listInt;
		int[] integers =  [ 1, 2, 3, 4, 5, 6, 7, 8 ];
		[SetUp]
		public void Setup()
		{
			listInt = new LinearDataStructures.LinkedList<int>();
			for(int i = 0; i < integers.Length; i++)
			{
				listInt.Add(integers[i]);
			}
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
			LinearDataStructures.LinkedList<int> list = new LinearDataStructures.LinkedList<int>();
			LinearDataStructures.LinkedList<string> listS = new LinearDataStructures.LinkedList<string>();
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
			LinearDataStructures.LinkedListNode<int> current = listInt.Head;
			while(current != null)
			{
				placeholder[index] = current.Data;
				index++;
				current = current.Next;
			}

			Assert.That(placeholder.Reverse().SequenceEqual<int>(integers));
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
			Assert.That(listInt[listInt.Count-1] == integers[integers.Length-1]);

			Assert.Throws<IndexOutOfRangeException>(()=> { var value = listInt[-1]; }, "Index cannot be negative");

			Assert.Throws<IndexOutOfRangeException>(()=> { var value = listInt[listInt.Count]; }, "Index out of range");
		}
	}
}
