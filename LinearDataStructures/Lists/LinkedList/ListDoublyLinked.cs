using System.Text;

namespace LinearDataStructures.Lists.LinkedList
{
    public class ListDoublyLinked<T> : IListBasics<T>
    {
        public ListDoublyLinkedNode<T>? Head;
        public ListDoublyLinkedNode<T>? Tail;

        public ListDoublyLinked()
        {
            Head = null;
        }

        public int Count { get; private set; } = 0;

        public T this[int index]
        {
            get
            {
                if (index < 0)
                {
                    throw new IndexOutOfRangeException("Invalid index (index must be a positive integer or zero)");
                }

                int i = 0;
                ListDoublyLinkedNode<T> current = Head;
                while (current != null)
                {
                    if (i == index)
                    {
                        return current.Data;
                    }

                    i++;
                    current = current.Next;
                }

                throw new IndexOutOfRangeException();
            }
        }

        public void Add(T data)
        {
            ListDoublyLinkedNode<T> newNode = new ListDoublyLinkedNode<T>(data, null, null);
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                ListDoublyLinkedNode<T>? current = Head;
                ListDoublyLinkedNode<T>? previous = null;

                while (current != null)
                {
                    previous = current;
                    current = current.Next;
                }
                current = new ListDoublyLinkedNode<T>(data, previous, null);
                previous.Next = current;
                Tail = current;
            }

            Count++;
        }

        public void Delete(T data)
        {
            if (Head == null)
            {
                return;
            }

            ListDoublyLinkedNode<T> current = Head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (Head.Next == null) //List of only 1 node
                    {
                        Head = null;
                        Tail = null;
                        Count--;
                        return;
                    }

                    if (current.Next == null) // Deleting the last node
                    {
                        Tail = current.Previous;
                        current.Previous.Next = null;
                        Count--;
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
                        Count--;
                        return;
                    }
                }
                current = current.Next;
            }

        }

        public int Search(T data)
        {
            if (Head == null) return -1;

            ListDoublyLinkedNode<T> current = Head;
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
            ListDoublyLinkedNode<T> newNode = new ListDoublyLinkedNode<T>(data, null, null);

            //Check if index is valid
            if (index > Count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            //check if 0 (inserting at the beginning of the list)
            if (index == 0)
            {
                if (Head == null)
                {
                    Add(data);
                    return;
                }

                newNode.Next = Head;
                Head.Previous = newNode;
                Head = newNode;
                Count++;
                return;
            }

            //check if inserting at the end
            if (index == Count)
            {
                Add(data);
                return;
            }


            //Insert in the middle:
            int currentIndex = 0;
            ListDoublyLinkedNode<T> current = Head;
            while (current != null)
            {
                //If this part is running list can't be empty;
                if (currentIndex == index)
                {
                    newNode.Next = current;
                    newNode.Previous = current.Previous;
                    current.Previous.Next = newNode;
                    newNode.Next.Previous = newNode;

                    Count++;
                    return;
                }
                current = current.Next;
                currentIndex++;
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0)
                throw new IndexOutOfRangeException("Index cannot be negative");

            if (index >= Count)
                throw new IndexOutOfRangeException("Position doesn't exist on the list");

            int i = 0;
            ListDoublyLinkedNode<T> current = Head;

            while (current != null)
            {
                if (i == index)
                {
                    if (current.Previous == null) // Case deleting first member
                    {
                        Head = current.Next;

                        if (Head == null) // List had only 1 member
                        {
                            Tail = Head;
                        }
                        else //List had more than 1 members
                        {
                            Head.Previous = null;
                        }
                    }
                    else // Deleting middle / last member:
                    {
                        current.Previous.Next = current.Next;
                        if (current.Next != null) // Case not deleting last member:
                        {
                            current.Next.Previous = current.Previous;
                        }
                        else // Deleting last member
                        {
                            Tail = current.Previous;
                        }
                    }

                    Count--;
                }

                i++;
                current = current.Next;
            }
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("[");
            StringBuilder previous = new StringBuilder("[");

            ListDoublyLinkedNode<T>? current = Head;

            while (current != null)
            {
                sb.Append(current.Data);
                sb.Append(", ");
                if (current.Previous != null)
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
            result += "Count: " + Count + " Head: " + Head + " Tail: " + Tail + Environment.NewLine;
            result += "Previous: " + previousString + "]" + Environment.NewLine;

            return result;
        }

        public static void Demo(T[] data)
        {
            int deletedNodeIndex = data.Length - 1;

            Console.WriteLine("S T A R T I N G Doubly Linked List DEMO:");
            Console.WriteLine("Creating list...");
            ListDoublyLinked<T> list = new ListDoublyLinked<T>();
            Console.WriteLine(list);
            Console.WriteLine("Adding elements to the list");
            for (int i = 0; i < data.Length - 1; i++)
            {
                list.Add(data[i]);
            }

            Console.WriteLine(list);
            Console.WriteLine($"Deleting element equal to {data[deletedNodeIndex]}...");
            list.Delete(data[deletedNodeIndex]);
            Console.WriteLine("Delete method finished");
            Console.WriteLine(list);
            Console.WriteLine("Searching for elements");
            for (int i = 0; i < data.Length; i++)
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
            Console.WriteLine();
            Console.WriteLine($"Inserting element {data[deletedNodeIndex]} at position {deletedNodeIndex - 1}");
            list.Insert(deletedNodeIndex - 1, data[deletedNodeIndex]);
            Console.WriteLine(list);

            Console.WriteLine("E N D   -doubly linked list demo finished");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
