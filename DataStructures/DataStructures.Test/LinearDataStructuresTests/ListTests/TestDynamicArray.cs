using DataStructures.LinearDataStructures.Lists.DynamicArray.ImplementingInterfaces;
using static DataStructures.Tests.LinearDataStructuresTests.LinearDataStructuresConstants;

namespace DataStructures.Tests.LinearDataStructuresTests.ListTests
{
	public class TestDynamicArray
	{

		[Test]
		public void ArrayDynamicICollectionBasicFunctionallity()
		{
			//Constructor empty
			ArrayDynamicICollection<int> emptyArray = new ArrayDynamicICollection<int>();

			Assert.DoesNotThrow(() => { ArrayDynamicICollection<int> array = new ArrayDynamicICollection<int>(); });
			Assert.DoesNotThrow(() => { ArrayDynamicICollection<string> array = new ArrayDynamicICollection<string>(); });
			Assert.That(emptyArray.Capacity, Is.EqualTo(2));
			Assert.That(emptyArray.Count, Is.EqualTo(0));

			//Constructor array
			ArrayDynamicICollection<int> array = new ArrayDynamicICollection<int>(INTS);
			Assert.That(array.Count == INTS.Length);
			Assert.That(array.Capacity, Is.EqualTo(INTS.Length));
		}
	}
}
