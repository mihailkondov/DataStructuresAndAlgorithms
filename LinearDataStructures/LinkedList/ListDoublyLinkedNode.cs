namespace LinearDataStructures.LinkedList
{
	public class ListDoublyLinkedNode<T>
    {
        public T? Data { get; set; }
        public ListDoublyLinkedNode<T>? Next { get; set; } = null;
        public ListDoublyLinkedNode<T>? Previous { get; set; } = null;

        public ListDoublyLinkedNode()
        {
            Next = null;
            Previous = null;
        }
        public ListDoublyLinkedNode(T data, ListDoublyLinkedNode<T> previous, ListDoublyLinkedNode<T> next)
        {
            Data = data;
            Previous = previous;
            Next = next;
        }

		public override string ToString()
		{
            return $"{Data}";
		}
	}
}
