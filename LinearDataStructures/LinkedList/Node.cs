namespace LinkedList
{
	public class Node
	{
		public Node(int data)
		{
			Data = data;
			Next = null;
		}
		public int Data { get; set; }
		public Node? Next { get; set; }
	}
}
