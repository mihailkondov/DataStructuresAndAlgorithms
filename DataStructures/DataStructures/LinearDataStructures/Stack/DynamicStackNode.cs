namespace DataStructures.LinearDataStructures.Stack
{
    public class DynamicStackNode<T>(T data)
    {
        public DynamicStackNode<T>? Next = null;
        public T Data = data;
    }
}
