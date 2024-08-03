//TODO: Make the linked List generic and implement enumerators
namespace LinkedList
{
	public class LinkedList
	{
		public LinkedList()
		{
			Head = null;
		}

		public Node? Head { get; private set; }
		public int Count { get; private set; } = 0;

		public void Add(int data)
		{
			if (Head == null)
			{
				Head = new Node(data);
				this.Count++;
			}
			else
			{
				Node current = Head;
				while (current.Next != null)
				{
					current = current.Next;
				}

				current.Next = new Node(data);
				Count++;
			}
		}

		public void Remove(int data)
		{
			if (Head is null || Head.Next is null) { return; } // List has no members => stop searching.

			Node current = Head;
			Node? next = Head.Next;
			if (current.Data == data)
			{
				Head = Head.Next;
				Count--;
				return;
			}
			while (next!=null)
			{
				if (next == null) return;
				if (next.Data == data)
				{
					current.Next = next.Next;
					Count--;
				}
				current = next;
				next = next.Next;
			}
		}

		public void Clear()
		{
			Head = null;
			Count = 0;
		}
		public void Print()
		{
			Console.WriteLine($"Printing list with {this.Count} members:");
			Node? current;
			current = this.Head;
			while (current != null)
			{
				Console.WriteLine(current.Data);
				current = current.Next;
			}
		}
		public void Reverse()
		{
			Console.WriteLine("Reversing list...");
			Node? current = this.Head;
			Node? previous = null;
			Node? savedNext;

			while (current != null)
			{
				savedNext = current.Next;
				current.Next = previous;
				this.Head = current;
				previous = current;
				current = savedNext;
			}
		}
	}
}
