using System.Collections;
using System.Text;

namespace DataStructures.LinearDataStructures.Lists.DynamicArray.ImplementingInterfaces
{
    public class ArrayDynamicIEnumerable<T> : IEnumerable<T>
    {
        protected int _capacity = 2;

        protected T[] _array;

        public int Count { get; protected set; } = 0;
        public int Capacity { get => _capacity; protected set => _capacity = value; }

        public ArrayDynamicIEnumerable()
        {
            _array = new T[_capacity];
        }
        public ArrayDynamicIEnumerable(T[] dataArray)
        {
            _array = new T[dataArray.Length];
            for (int i = 0; i < dataArray.Length; i++)
            {
                _array[i] = dataArray[i];
            }
            _capacity = dataArray.Length;
            Count = _capacity;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int i = 0;
            while (i < Count)
            {
                yield return _array[i++];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
