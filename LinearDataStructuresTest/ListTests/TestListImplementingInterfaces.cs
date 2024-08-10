using LinearDataStructures.Lists.DynamicArray.ImplementingInterfaces;
using static Tests.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tests.ListTests
{
    internal class TestListImplementingInterfaces
    {
        IEnumerable<int> enumerableInt;
        IEnumerable<string> enumerableStr;
        ICollection<int> collectionInt;
        ICollection<string> collectionStr;
        IList<int> listInt;
        IList<string> listStr;
        int[] numbers;
        string[] strings;

        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void ArrayDynamicIEnumerableBasicFunctionallity()
        {
            //Constructor empty
            ArrayDynamicIEnumerable<int> emptyArray = new ArrayDynamicIEnumerable<int>();

            Assert.DoesNotThrow(() => { ArrayDynamicIEnumerable<int> array = new ArrayDynamicIEnumerable<int>(); });
            Assert.DoesNotThrow(() => { ArrayDynamicIEnumerable<string> array = new ArrayDynamicIEnumerable<string>(); });
            Assert.That(emptyArray.Capacity, Is.EqualTo(2));
            Assert.That(emptyArray.Count, Is.EqualTo(0));

            //Constructor array
            ArrayDynamicIEnumerable<int> array = new ArrayDynamicIEnumerable<int>(INTS);
            Assert.That(array.Count == INTS.Length);
            Assert.That(array.Capacity, Is.EqualTo(INTS.Length));
        }

        [Test]
        public void ArrayDynamicIEnumerableIterate()
        {
            //Arrange
            int[] numbers = new int[INTS.Length];
            string[] strings = new string[STRINGS.Length];
            enumerableInt = new ArrayDynamicIEnumerable<int>(INTS);
            enumerableStr = new ArrayDynamicIEnumerable<string>(STRINGS);
            //Act
            int i = 0;
            foreach (int number in enumerableInt)
            {
                numbers[i++] = number;
            }

            i = 0;
            foreach (string str in enumerableStr)
            {
                strings[i++] = str;
            }
            //Assert
            Assert.That(numbers, Is.EqualTo(INTS));
            Assert.That(strings, Is.EqualTo(STRINGS));
        }

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
