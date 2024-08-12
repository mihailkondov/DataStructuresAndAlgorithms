using DataStructures.Demos;
using DataStructures.Demos.StackDemos;
using DataStructures.LinearDataStructures.Lists.LinkedList;

namespace DataStructures.Core
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DynamicArray.Demo();
            //DoublyLinkedList<int>.Demo(new int[]{ 100, 20, 15, 1432 });

            ListLinked<IDemo> list = new ListLinked<IDemo>();
            IDemo stackDemo = new StackDemo();
            list.Add(stackDemo);

            foreach (IDemo item in list)
            {
                item.Run();
            }
        }
    }
}
