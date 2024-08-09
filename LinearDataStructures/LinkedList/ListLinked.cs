//TODO: Make the linked List generic and implement enumerators
using LinearDataStructures.LinkedList;
using System.Collections;

namespace LinearDataStructures
{
	public class ListLinked<T> : IListBasics<T>, IEnumerable<T>
	{
		public ListLinked()
		{
			Head = null;
		}

		public int Count { get; private set; } = 0;

		public ListLinkedNode<T>? Head { get; private set; }

		//Indexer
		public T this[int index]
		{
			get
			{
				if (index < 0) throw new IndexOutOfRangeException("Index cannot be negative");

				int i = 0;
				ListLinkedNode<T> node = Head;
				while (i < Count)
				{
					if(i == index)
					{
						return node.Data;
					}
					i++;
					node = node.Next;
				}

				throw new IndexOutOfRangeException("Index out of range");
			}
		}

		public void Add(T data)
		{
			if (Head == null)
			{
				Head = new ListLinkedNode<T>(data);
				this.Count++;
			}
			else
			{
				ListLinkedNode<T> current = Head;
				while (current.Next != null)
				{
					current = current.Next;
				}

				current.Next = new ListLinkedNode<T>(data);
				Count++;
			}
		}

		public void Delete(T data)
		{
			if (Head is null) { return; } // List has no members => stop searching.

			ListLinkedNode<T> current = Head;
			ListLinkedNode<T>? next = Head.Next;
			if (current.Data.Equals(data))
			{
				Head = Head.Next;
				Count--;
				return;
			}
			while (next!=null)
			{
				if (next == null) return;
				if (next.Data.Equals(data))
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
			ListLinkedNode<T>? current;
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
			ListLinkedNode<T>? current = this.Head;
			ListLinkedNode<T>? previous = null;
			ListLinkedNode<T>? savedNext;

			while (current != null)
			{
				savedNext = current.Next;
				current.Next = previous;
				this.Head = current;
				previous = current;
				current = savedNext;
			}
		}

		public int Search(T data)
		{
			if (Head == null) return -1;

			ListLinkedNode<T> current = this.Head;
			int index = 0;
			while (current != null)
			{
				if (current.Data == null)
				{
					if (data == null)
					{
						return index;
					}
					return -1;
				}

				if (current.Data.Equals(data)) return index;

				current = current.Next;
				index++;
			}

			return -1;
		}

		public void Insert(int index, T data)
		{
			if (index > Count)
			{
				throw new ArgumentOutOfRangeException();
			}

			if(this.Head == null)
			{
				this.Head = new ListLinkedNode<T>(data);
				Count = 1;
				return;
			}

			int currentIndex = 0;
			ListLinkedNode<T> currentNode = this.Head;
			ListLinkedNode<T> newNode;
			while (currentIndex < index)
			{
				currentIndex++;
				if(currentIndex == index)
				{
					newNode = new ListLinkedNode<T>(data);
					newNode.Next = currentNode.Next;
					currentNode.Next = newNode;
					Count++;
					return;
				}
				
				currentNode = currentNode.Next;
			}

			//Case Inserting at position 0
			newNode = new ListLinkedNode<T>(data);
			newNode.Next = Head;
			Head = newNode;
			Count++;
		}

		public void AddFirst(T data)
		{
			Insert(0, data);
		}
		public void AddLast(T data)
		{
			Insert(Count, data);
		}
		public void AddBefore(T find, T data)
		{
			Insert(Search(find), data);
		}
		public void AddAfter(T find, T data)
		{
			Insert(Search(find) + 1, data);
		}

		//IEnumerable implementation
		public IEnumerator<T> GetEnumerator()
		{
			ListLinkedNode<T> current = this.Head;
			while (current != null)
			{
				yield return current.Data;
				current = current.Next;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public static void Demo()
		{
			ListLinked<int> list = new ListLinked<int>();
			list.Add(100);
			list.Add(200);
			list.Add(300);

            Console.WriteLine("S T A R T I N G Linked List Demo");
            Console.WriteLine("Foreach loop works because IEnumerable is implemented:");
            foreach (int i in list)
			{
				Console.WriteLine(i);
			}
            Console.WriteLine("For loop works with just the indexer:");
            for (int i = 0; i < list.Count; i++)
			{
				Console.WriteLine(list[i]);
			}
		}
	}
}
