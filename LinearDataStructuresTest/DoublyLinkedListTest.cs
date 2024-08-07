using LinearDataStructures.LinkedList;

namespace Tests
{
    public class DoublyLinkedListTest
	{
		DoublyLinkedList<int> listInt;
		DoublyLinkedList<object> listObj;
		DoublyLinkedList<int> populatedList;
		static List<int> numbers = [0, 100, 200, 300, 400];

		[SetUp]
		public void Setup()
		{
			listInt = new DoublyLinkedList<int>();
			listObj = new DoublyLinkedList<object>();
			populatedList = new DoublyLinkedList<int>();
			populatedList.Add(numbers[0]);
			populatedList.Add(numbers[1]);
			populatedList.Add(numbers[2]);
			populatedList.Add(numbers[3]);
			populatedList.Add(numbers[4]);
		}

		[Test]
		public void Enumerator()
		{
			Assert.That(populatedList[0] == numbers[0]);
			Assert.That(populatedList[4] == numbers[4]);
			Assert.Throws<IndexOutOfRangeException>(() => { var value = populatedList[-1]; });
			Assert.Throws<IndexOutOfRangeException>(() => { var value = populatedList[numbers.Count]; });
		}

		[Test]
		public void Add()
		{
			var whatever = new { sfd = "dd", mhm="ok", somethingelse= 3, gotit= 4 };
			listObj.Add(whatever);
			Assert.That(listObj.Head.Data.Equals( whatever));
			Assert.That(listObj.Head.Next == null);
			Assert.That(listObj.Head.Previous == null);

			listInt.Add(numbers[0]);
			Assert.That(listInt.Head.Data == listInt.Tail.Data && listInt.Head.Data == numbers[0]);
			
			listInt.Add(numbers[1]);
			Assert.That(listInt.Head.Data == numbers[0]);
			Assert.That(listInt.Tail.Data == numbers[1]);


			listInt.Add(numbers[2]);
			Assert.That(listInt.Head.Data == numbers[0]);
			Assert.That(listInt.Tail.Data == numbers[2]);
			listInt.Add(numbers[3]);

			Assert.That(listInt.Head.Data == numbers[0]);
			Assert.That(listInt.Tail.Data == numbers[3]);

		}

		[Test]
		public void Delete()
		{
			populatedList.Delete(numbers[1]);
			Assert.That(populatedList.Head.Data == numbers[0]);
			Assert.That(populatedList.Head.Next.Data == numbers[2]);
			Assert.That(populatedList.Tail.Data == numbers[4]);
		}

		[Test]
		public void DeleteFirst()
		{
			populatedList.Delete(numbers[0]);
			Assert.That(populatedList.Head.Data == numbers[1]);
			Assert.That(populatedList.Tail.Data == numbers[numbers.Count - 1]);
			Assert.That(populatedList.Count == numbers.Count - 1);
		}

		[Test]
		public void DeleteLast()
		{
			populatedList.Delete(numbers[numbers.Count-1]);
			Assert.That(populatedList.Head.Data == numbers[0]);
			Assert.That(populatedList.Tail.Data == numbers[numbers.Count - 2]);
			Assert.That(populatedList.Count == numbers.Count - 1);
		}

		[Test]
		public void Insert()
		{
			listInt.Insert(0, numbers[0]);  //Insert First
			listInt.Insert(1, numbers[1]); //Insert Last
			populatedList.Insert(1, numbers[3]); //Insert Middle

			Assert.That(listInt.Head.Data == numbers[0]);
			Assert.That(listInt.Head.Next.Data == numbers[1]);
			Assert.That(populatedList.Head.Next.Data == numbers[3]);

			Assert.That(listInt.Count == 2);
			Assert.That(populatedList.Count == 6);
			Assert.That(listInt.Head.Data == numbers[0]);
			Assert.That(listInt.Tail.Data == numbers[1]);

			Assert.That(populatedList.Head.Data == numbers[0]);
			Assert.That(populatedList.Tail.Data == numbers[4]);
			
		}

		[Test, TestCaseSource(nameof(numbers))]
		public void SearchFound(int value)
		{
			Assert.That(populatedList.Search(value) == numbers.IndexOf(value));
		}

		[Test]
		public void SearchNotFound()
		{
			Assert.That(populatedList.Search(12345) == -1); // should return -1 when not found
		}

		[Test]
		public void Count()
		{
			int count = 0;
			Assert.That(listInt.Count == count);
			
			//Add
			listInt.Add(numbers[0]);
			count++;
			Assert.That(listInt.Count == count);

			//After Insertion in the beginning
			listInt.Insert(0, numbers[1]);
			count++;
			Assert.That(listInt.Count == count);

            //After Insertion in the end
            listInt.Insert(count, numbers[2]);
			count++;
			Assert.That(listInt.Count == count);

			//Delete
			listInt.Delete(listInt.Head.Data);
			count--;
			Assert.That(listInt.Count == count);

		}

		[Test]
		public void RemoveAtFirst()
		{
			//Remove first member
			populatedList.RemoveAt(0);
			Assert.That(populatedList.Count == numbers.Count - 1); //Count changed
			Assert.That(populatedList.Head.Data == numbers[1]); //Head was moved
		}

		[Test]
		public void RemoveAtMiddle()
		{
			//Remove from the middle
			populatedList.RemoveAt(1);
			Assert.That(populatedList.Count == numbers.Count - 1);
			Assert.That(populatedList[0] == numbers[0]);
			Assert.That(populatedList[1] == numbers[2]);
			Assert.That(populatedList.Head.Data == numbers[0]); //Head unchanged
			Assert.That(populatedList.Tail.Data == numbers[numbers.Count - 1]); //Tail unchanged
		}

		[Test]
		public void RemoveAtLast()
		{
			//Remove last member
			populatedList.RemoveAt(numbers.Count - 1);
			Assert.That(populatedList.Count == numbers.Count - 1);  //Count changes
			Assert.That(populatedList[0] == numbers[0]);
			Assert.That(populatedList[1] == numbers[1]);
			Assert.That(populatedList[2] == numbers[2]);
			Assert.That(populatedList[3] == numbers[3]);
			Assert.That(populatedList.Tail.Data == numbers[3]); //Tail was moved
		}

		[Test]
		public void RemoveAtThrows() 
		{ 
			//Index out of bounds (too high)
			Assert.Throws<IndexOutOfRangeException>(() => listInt.RemoveAt(5), "Position doesn't exist on the list");

			//Index is negative
			Assert.Throws<IndexOutOfRangeException>(() => listInt.RemoveAt(-1), "Index cannot be negative");
		}

		[Test]
		public void AddLast() 
		{
			listInt.AddLast(100);
			Assert.That(listInt.Count == 1);
			Assert.That(listInt.Head.Data == 100);

			listInt.AddLast(200);
			Assert.That(listInt.Count == 2);
			Assert.That(listInt.Head.Next.Data == 200);

			populatedList.AddLast(1337);
			Assert.That(populatedList.Tail.Data == 1337);
			Assert.That(populatedList.Count == 6);
		}

		[Test]
		public void AddFirst() 
		{
			listInt.AddFirst(123);
			Assert.That(listInt.Head.Data == 123);

			listInt.AddFirst(3210);
			Assert.That(listInt.Head.Data == 3210);
		}

		[Test]
		public void AddBefore() 
		{
			populatedList.AddBefore(200, 999);
			Assert.That(populatedList.Count == 6);
			Assert.That(populatedList.Head.Next.Next.Data == 999);
			Assert.That(populatedList.Head.Next.Next.Next.Data == 200);
		}
		
		[Test]
		public void AddAfter() 
		{
			populatedList.AddAfter(100, 999);
			Assert.That(populatedList.Count == 6);
			Assert.That(populatedList.Head.Next.Data == 100);
			Assert.That(populatedList.Head.Next.Next.Data == 999);
			Assert.That(populatedList.Head.Next.Next.Next.Data == 200);
		}
	}
}