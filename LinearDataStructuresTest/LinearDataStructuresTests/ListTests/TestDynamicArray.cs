using LinearDataStructures.LinearDataStructures.Lists.DynamicArray.ImplementingInterfaces;
using static Tests.LinearDataStructuresTests.LinearDataStructuresConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.ListTests
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
