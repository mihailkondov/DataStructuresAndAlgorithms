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
			listInt.Add(numbers[1]);
			listInt.Add(numbers[2]);
			listInt.Add(numbers[3]);

			Assert.That(listInt.Head.Data == numbers[0]);
		}


		[Test]
		public void Delete()
		{
			populatedList.Delete(numbers[1]);
			Assert.That(populatedList.Head.Data == numbers[0]);
			Assert.That(populatedList.Head.Next.Data == numbers[2]);
		}

		[Test]
		public void Insert()
		{
			listInt.Insert(0, numbers[0]);
			listInt.Insert(1, numbers[1]);
			populatedList.Insert(1, numbers[3]);

			Assert.That(listInt.Head.Data == numbers[0]);
			Assert.That(listInt.Head.Next.Data == numbers[1]);
			Assert.That(populatedList.Head.Next.Data == numbers[3]);
			
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
		public void RemoveAt()
		{
			//Delete first
			populatedList.RemoveAt(0);
			Assert.That(populatedList.Count == numbers.Count - 1);
			Assert.That(populatedList.Head.Data == numbers[1]);

			//Delete in the middle
			populatedList.RemoveAt(1);
			Assert.That(populatedList.Count == numbers.Count - 2);
			Assert.That(populatedList[0] == numbers[1]);
			Assert.That(populatedList[1] == numbers[3]);

			//Delete last
			populatedList.RemoveAt(numbers.Count - 3);
			Assert.That(populatedList.Count == numbers.Count - 3);
			Assert.That(populatedList[0] == numbers[1]);
			Assert.That(populatedList[1] == numbers[3]);


			//Index out of bounds (too high)
			Assert.Throws<IndexOutOfRangeException>(() => listInt.RemoveAt(2), "Position doesn't exist on the list");

			//Index is negative
			Assert.Throws<IndexOutOfRangeException>(() => listInt.RemoveAt(-1), "Index cannot be negative");

		}
	}
}