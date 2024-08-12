namespace LinearDataStructures.LinearDataStructures.Lists.LinkedList
{
    public class ListLinkedNode<T>
    {
        public ListLinkedNode(T data)
        {
            Data = data;
            Next = null;
        }
        public T Data { get; set; }
        public ListLinkedNode<T>? Next { get; set; }
    }
}
