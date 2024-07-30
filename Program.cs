namespace DynamicArrays
{
	internal class Program
	{
		static void Main(string[] args)
		{
			DynamicArray dynamicArray = new DynamicArray();
			dynamicArray.add("A");
			dynamicArray.add("B");
			dynamicArray.add("C");
			Console.WriteLine(dynamicArray);
		}
	}
}
