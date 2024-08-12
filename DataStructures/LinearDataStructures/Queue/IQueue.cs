namespace DataStructures.LinearDataStructures.Queue
{
	internal interface IQueue<T>
    {
        void Enqueue(T data);
        T Dequeue();
        T Peek();
        void Clear();
        bool Contains(T data);
        T[] ToArray();
        void TrimExcess();
    }
}
