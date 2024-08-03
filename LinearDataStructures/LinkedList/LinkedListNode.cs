namespace LinearDataStructures
{
	public class LinkedListNode<T>
	{
		public LinkedListNode(T data)
		{
			Data = data;
			Next = null;
		}
		public T Data { get; set; }
		public LinkedListNode<T>? Next { get; set; }
	}
}
