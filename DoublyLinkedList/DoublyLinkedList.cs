using LinearDataStructures.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//1793
namespace LinearDataStructures.DoublyLinkedList
{
    public class DoublyLinkedList<T>: IBasics<T>
    {
        public DoublyLinkedListNode<T> ?Head;

		public DoublyLinkedList()
        {
            Head = null;
        }

        public void Add(T data)
        {
            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(data, null, null);
            if(Head == null)
            {
                Head = newNode;
			}
            else
            {
				DoublyLinkedListNode<T>? current = Head;
				DoublyLinkedListNode<T>? previous = null;

				while (current != null)
				{
                    previous = current;
					current = current.Next;
				}
                current = new DoublyLinkedListNode<T>(data, previous, null);
                previous.Next = current;
			}

        } //Done

        public void Delete(T data)
        {
            if(Head == null)
            {
                return;
            }

  

            DoublyLinkedListNode<T> current = Head;
            while(current != null)
            {
                if (current.Data.Equals(data))
                {
					if (Head.Next == null) //List of only 1 node
					{
						Head = null;
						return;
					}

					if (current.Next == null) // Deleting the last node
                    {
						current.Previous.Next = null;
                        return;
					}
                    else
                    {
						if (current.Previous == null) //Deleting the first node
						{
							Head = current.Next;
							current.Next.Previous = null;
						}
						else //Deleting middle node (most common case)
						{
							current.Previous.Next = current.Next;
							current.Next.Previous = current.Previous;
						}
						return;
					}
				}
                current = current.Next;
            }
            
        } //Done

        public int Search(T data)
        {
            if (Head == null) return -1;
            
            DoublyLinkedListNode<T> current = Head;
            int index = 0;
            while (current != null)
            {
                if(current.Data == null)
                {
                    if(data == null)
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
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("[");
            StringBuilder previous = new StringBuilder("[");

			DoublyLinkedListNode<T>? current = this.Head;

            while (current != null)
            {
                sb.Append(current.Data);
                sb.Append(", ");
                if(current.Previous != null)
                {
                    previous.Append(current.Previous.Data);
					previous.Append(", ");

				}
                else
                {
					previous.Append("null");
					previous.Append(", ");
				}
				current = current.Next;
            }
            string result = sb.ToString().TrimEnd(' ', ',');
            string previousString = previous.ToString().TrimEnd(' ', ',');
            result += "]";
            result += Environment.NewLine;
            result += "Previous: " + previousString + "]";
            return result;
        } //Done
        public static void Demo(T[] data) //This part should be replaced by unit tests
        {
            int deletedNodeIndex = data.Length-1;

            Console.WriteLine("S T A R T I N G Doubly Linked List test:");
            Console.WriteLine("Creating list...");
            DoublyLinkedList<T> list = new DoublyLinkedList<T>();
            Console.WriteLine(list);
            Console.WriteLine("Adding elements to the list");
            for(int i = 0; i<data.Length-1; i++)
            {
                list.Add(data[i]);
            }

            Console.WriteLine(list);
            Console.WriteLine($"Deleting element equal to {data[deletedNodeIndex]}...");
            list.Delete(data[deletedNodeIndex]);
            Console.WriteLine("Delete method finished");
            Console.WriteLine(list);
            Console.WriteLine("Searching for elements");
            for(int i = 0; i < data.Length; i++)
            {
                Console.Write($"Looking for index of {data[i]}... ");
                int found = list.Search(data[i]);
                if (found > -1)
                {
                    Console.WriteLine($"Found at index {found}");
                }
                else
                {
                    Console.WriteLine($"Not found (returned index {found})");
                }
            }

        }
    }
}
