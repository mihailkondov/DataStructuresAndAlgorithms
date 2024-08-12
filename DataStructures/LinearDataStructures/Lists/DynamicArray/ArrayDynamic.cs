using System.Text;

namespace DataStructures.LinearDataStructures.Lists.DynamicArray
{
    internal class ArrayDynamic
    {
        internal int capacity = 10;
        internal int Count { get; private set; } = 0;
        internal object[] array;

        public ArrayDynamic()
        {
            array = new object[capacity];
        }
        public ArrayDynamic(int capacity)
        {
            array = new object[capacity];
        }

        public void Add(object data)
        {
            if (Count >= capacity)
            {
                Grow();
            }
            array[Count] = data;
            Count++;
        }
        public void Insert(int index, object data)
        {
            if (index > Count || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (Count == capacity)
            {
                Grow();
            }

            for (int i = Count; i > index; i--)
            {
                array[i] = array[i - 1];
            }
            array[index] = data;
            Count++;
        }
        public void Delete(object data)
        {
            int index = -1;
            for (int i = 0; i < Count; i++)
            {
                if (array[i] == data)
                {
                    index = i;
                    break;
                }
            }
            if (index > -1)
            {
                for (int i = index; i < Count - 1; i++)
                {
                    array[i] = array[i + 1];
                }
                Count--;
                if (Count < capacity / 3)
                {
                    Shrink();
                }
            }
        }
        public int Search(object data)
        {
            for (int i = 0; i < Count; i++)
            {
                if (array[i].Equals(data))
                {
                    return i;
                }
            }

            return -1;
        }
        private void Grow()
        {
            capacity *= 2;
        }
        private void Shrink()
        {
            capacity /= 2;
        }
        public bool IsEmpty()
        {
            if (Count > 0)
                return false;
            if (Count == 0)
                return true;
            throw new ArgumentOutOfRangeException(paramName: "Count", message: "DynamicArray Count property is negative");
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("[");
            for (int i = 0; i < Count; i++)
            {
                sb.Append(array[i]);
                sb.Append(", ");
            }
            string result = sb.ToString().TrimEnd(' ', ',');
            result += "]";
            return result;
        }

        public static void Demo()
        {
            Console.WriteLine("S T A R T I N G   Dynamic Array Demo:" + Environment.NewLine);
            ArrayDynamic dynamicArray = new ArrayDynamic();
            dynamicArray.Add("A");
            dynamicArray.Add("B");
            dynamicArray.Add("C");
            dynamicArray.Insert(3, "D");
            dynamicArray.Insert(4, "E");
            dynamicArray.Delete("A");
            dynamicArray.Delete("E");
            Console.WriteLine(dynamicArray);
            Console.WriteLine("Capacity: {0}", dynamicArray.capacity);
            Console.WriteLine("Size: {0}", dynamicArray.Count);

            Console.WriteLine("Index of B is " + dynamicArray.Search("B"));
            Console.WriteLine("Index of X is " + dynamicArray.Search("X"));

            Console.WriteLine("Testing capacity grow/shrink methods:");
            dynamicArray.Delete("B");
            dynamicArray.Delete("C");
            dynamicArray.Delete("D");
            Console.WriteLine(dynamicArray);
            Console.WriteLine($"Deleted 4 items. Capacity is {dynamicArray.capacity}. Count: {dynamicArray.Count}");
            dynamicArray.Add("A");
            dynamicArray.Add("B");
            dynamicArray.Add("C");
            dynamicArray.Add("D");
            dynamicArray.Add("E");
            dynamicArray.Add("F");
            Console.WriteLine(dynamicArray);
            Console.WriteLine($"Added 6 elements. Capacity is {dynamicArray.capacity}. Count: {dynamicArray.Count}");
            Console.WriteLine($"The array is empty: {dynamicArray.IsEmpty()}");
            Console.WriteLine();

            Console.WriteLine("Removing all elements...");
            dynamicArray.Delete("A");
            dynamicArray.Delete("B");
            dynamicArray.Delete("C");
            dynamicArray.Delete("D");
            dynamicArray.Delete("E");
            dynamicArray.Delete("F");
            Console.WriteLine(dynamicArray);
            Console.WriteLine($"The array is empty: {dynamicArray.IsEmpty()}");

            Console.WriteLine(Environment.NewLine + "F I N I S H E D   Dynamic Array Demo Finished." + Environment.NewLine);

        }

    }
}
