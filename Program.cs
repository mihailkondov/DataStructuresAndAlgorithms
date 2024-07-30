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
        }
	}
}
