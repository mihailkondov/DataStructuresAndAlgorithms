//TODO: Make the linked List generic and implement enumerators
using LinearDataStructures.Interfaces;
using System.Runtime.InteropServices;

namespace LinearDataStructures
{
	public class LinkedList<T> : IBasics<T>
	{
		public LinkedList()
		{
			Head = null;
		}

		public int Count { get; private set; } = 0;
		public LinkedListNode<T>? Head { get; private set; }

		public T this[int index]
		{
			get
			{
				if (index < 0) throw new IndexOutOfRangeException("Index cannot be negative");

				int i = 0;
				LinkedListNode<T> node = Head;
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
				Head = new LinkedListNode<T>(data);
				this.Count++;
			}
			else
			{
				LinkedListNode<T> current = Head;
				while (current.Next != null)
				{
					current = current.Next;
				}

				current.Next = new LinkedListNode<T>(data);
				Count++;
			}
		}

		public void Delete(T data)
		{
			if (Head is null) { return; } // List has no members => stop searching.

			LinkedListNode<T> current = Head;
			LinkedListNode<T>? next = Head.Next;
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
			LinkedListNode<T>? current;
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
			LinkedListNode<T>? current = this.Head;
			LinkedListNode<T>? previous = null;
			LinkedListNode<T>? savedNext;

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

			LinkedListNode<T> current = this.Head;
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
			if (index == 0)
			{
				this.Head = new LinkedListNode<T> ( data );
				return;
			}

			if(this.Head == null)
			{
				throw new ArgumentOutOfRangeException();
			}

			int currentIndex = 0;
			LinkedListNode<T> currentNode = this.Head;
			while(currentIndex < index)
			{
				currentIndex++;
				if(currentNode.Next  == null)
				{
					if(currentIndex == index)
					{
						currentNode.Next = new LinkedListNode<T>(data);
					}
					else
					{
						throw new ArgumentOutOfRangeException();
					}
				}
				currentNode = currentNode.Next;
			}
			currentNode.Next = new LinkedListNode<T>(data);
		}
	}
}
