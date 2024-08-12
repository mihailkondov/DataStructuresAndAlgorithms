namespace LinearDataStructures.LinearDataStructures.Stack
{
    public interface IStack<T>
    {
        T Peek();
        T Pop();
        void Push(T data);
    }
}
