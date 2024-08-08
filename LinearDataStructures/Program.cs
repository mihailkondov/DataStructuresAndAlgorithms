using LinearDataStructures.Demos;

namespace LinearDataStructures
{
    internal class Program
	{
		static void Main(string[] args)
		{
			//DynamicArray.Demo();
			//DoublyLinkedList<int>.Demo(new int[]{ 100, 20, 15, 1432 });

			LinkedList<IRunable> list = new LinkedList<IRunable>();
			IRunable stackDemo = new StackDemo();
			list.Add(stackDemo);

			foreach (IRunable item in list)
			{
				item.Run();
			}
        }
	}
}
