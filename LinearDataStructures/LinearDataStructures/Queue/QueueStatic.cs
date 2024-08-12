namespace LinearDataStructures.LinearDataStructures.Queue
{
    public class QueueStatic<T> : IQueue<T>
    {
        static int _initialCapacity = 2;
        private T[] _dataArray = new T[_initialCapacity];
        private int _head = 0;
        private int _tail = -1;
        private int _capacity = _initialCapacity;

        public int Count { get; private set; } = 0;
        public int Capacity { get => _capacity; }

        private void Grow()
        {
            ;
            if (Count == 0)
            {
                _capacity = _initialCapacity;
                return;
            }

            T[] oldArray = _dataArray;
            T[] newArray = new T[oldArray.Length * 2];
            int oldCapacity = _capacity;
            _capacity = newArray.Length;

            int cursorNA = 0;
            int cursorOA = _head;
            while (cursorOA < oldCapacity)
            {
                newArray[cursorNA++] = oldArray[cursorOA++];
            }

            int countMinusOne = Count - 1;
            while (cursorNA < countMinusOne)
            {
                newArray[cursorNA] = oldArray[cursorOA - oldArray.Length];
                cursorNA++;
                cursorOA++;
            }

            _dataArray = newArray;
            _head = 0;
            _tail = cursorNA - 1;
        }

        private void Shrink()
        {
            T[] oldArray = _dataArray;
            T[] newArray = new T[oldArray.Length / 2];
            int oldCapacity = _capacity;
            _capacity = newArray.Length;

            int cursorNA = 0;
            int cursorOA = _head;
            while (cursorOA < oldCapacity && cursorNA < Count)
            {
                newArray[cursorNA] = oldArray[cursorOA];
                cursorNA++;
                cursorOA++;
            }

            int countMinusOne = Count - 1;
            while (cursorNA < countMinusOne)
            {
                newArray[cursorNA] = oldArray[cursorOA - oldArray.Length];
                cursorNA++;
                cursorOA++;
            }

            _dataArray = newArray;
            _head = 0;
            _tail = cursorNA - 1;
        }

        public T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException("Cannot dequeue from an empty queue.");

            if (Count * 3 < _capacity)
            {
                Shrink();
            }

            T result = _dataArray[_head++];
            if (_head == _capacity) // head carry over to the beginning instead of out of bounds
            {
                _head = 0;
            }

            Count--;
            return result;
        }

        public void Enqueue(T data)
        {
            if (Count == _capacity)
            {
                Grow();
            }

            if (_tail + 1 == _capacity)
            {
                _tail = 0;
            }
            else
            {
                _tail++;
            }

            _dataArray[_tail] = data;

            Count++;
        }

        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException("Queue is empty. Can only peek in a queue with 1 or more members");

            return _dataArray[_head];
        }

        public void Clear()
        {
            Count = 0;
            _capacity = _initialCapacity;
            _head = 0;
            _tail = 0;
            _dataArray = new T[_initialCapacity];
        }

        public bool Contains(T data)
        {
            if (Count == 0)
            {
                return false;
            }

            foreach (T item in _dataArray)
            {
                if (item.Equals(data))
                {
                    return true;
                }
            }

            return false;
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];
            int cursor = _head;
            int copies = 0;
            while (cursor < _capacity && copies < Count)
            {
                array[copies++] = _dataArray[cursor++];
            }

            cursor = 0;

            while (copies < Count)
            {
                array[copies++] = _dataArray[cursor];
            }

            return array;
        }

        public void TrimExcess()
        {
            _dataArray = ToArray();
            _capacity = _dataArray.Length;
            _head = 0;
            _tail = _capacity - 1;
        }
    }
}
