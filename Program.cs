namespace DynamicArrays
{
	internal class Program
	{
		static void Main(string[] args)
		{
			DynamicArray dynamicArray = new DynamicArray();
			dynamicArray.Add("A");
			dynamicArray.Add("B");
			dynamicArray.Add("C");
			dynamicArray.Insert(3,"D");
			dynamicArray.Insert(4,"E");
			dynamicArray.Delete("A");
			dynamicArray.Delete("E");
			Console.WriteLine(dynamicArray);
            Console.WriteLine("Capacity: {0}", dynamicArray.capacity);
            Console.WriteLine("Size: {0}", dynamicArray.Count);
        }
	}
}
