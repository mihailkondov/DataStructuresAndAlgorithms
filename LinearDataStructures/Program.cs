using LinearDataStructures.Demos;

namespace LinearDataStructures
{
    internal class Program
	{
		static void Main(string[] args)
		{
			//DynamicArray.Demo();
			//DoublyLinkedList<int>.Demo(new int[]{ 100, 20, 15, 1432 });

			ListLinked<IDemoRunable> list = new ListLinked<IDemoRunable>();
			IDemoRunable stackDemo = new StackDemo();
			list.Add(stackDemo);

			foreach (IDemoRunable item in list)
			{
				item.Run();
			}
        }
	}
}
