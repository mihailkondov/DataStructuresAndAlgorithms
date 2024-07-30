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
			Console.WriteLine(dynamicArray);
		}
	}
}
