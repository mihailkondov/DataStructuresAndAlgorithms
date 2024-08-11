using LinearDataStructures.Lists.DynamicArray.ImplementingInterfaces;
using static Tests.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.ObjectModel;

namespace Tests.ListTests
{
	[TestFixture]
	internal class TestListImplementingInterfaces
	{
		ArrayDynamicIEnumerable<int> enumerableInt;
		ArrayDynamicIEnumerable<string> enumerableStr;
		ArrayDynamicICollection<int> collectionInt;
		ArrayDynamicICollection<string> collectionStr;
		ArrayDynamicIList<int> listInt;
		ArrayDynamicIList<string> listStr;
		static int[] forWhateverReasonIHaveToDeclareThis = INTS;
		static string[] forWhateverReasonIHaveToDeclareThisToo = STRINGS;

		[SetUp]
		public void SetUp()
		{
			enumerableInt = new ArrayDynamicIEnumerable<int>(INTS);
			enumerableStr = new ArrayDynamicIEnumerable<string>(STRINGS);
			collectionInt = new ArrayDynamicICollection<int>(INTS);
			collectionStr = new ArrayDynamicICollection<string>(STRINGS);
			listInt = new ArrayDynamicIList<int>(INTS);
			listStr = new ArrayDynamicIList<string>(STRINGS);

		}

		#region basic functionality tests
		[Test]
		public void Constructors()
		{
			ArrayDynamicIEnumerable<int> emptyArray = new ArrayDynamicIEnumerable<int>();
			ArrayDynamicIEnumerable<int> array = new ArrayDynamicIEnumerable<int>(INTS);

			Assert.DoesNotThrow(() => { ArrayDynamicIEnumerable<int> array = new ArrayDynamicIEnumerable<int>(); });
			Assert.DoesNotThrow(() => { ArrayDynamicIEnumerable<string> array = new ArrayDynamicIEnumerable<string>(); });
			Assert.That(emptyArray.Capacity, Is.EqualTo(2));
			Assert.That(emptyArray.Count, Is.EqualTo(0));

			Assert.DoesNotThrow(() =>
			{
				enumerableInt = new ArrayDynamicIEnumerable<int>(INTS);
				enumerableStr = new ArrayDynamicIEnumerable<string>(STRINGS);
				collectionInt = new ArrayDynamicICollection<int>(INTS);
				collectionStr = new ArrayDynamicICollection<string>(STRINGS);
				listInt = new ArrayDynamicIList<int>(INTS);
				listStr = new ArrayDynamicIList<string>(STRINGS);
			});
		}

		[Test]
		public void Count()
		{
			Assert.That(enumerableInt.Count == INTS.Length);
			Assert.That(enumerableStr.Count == STRINGS.Length);

			Assert.That(collectionInt.Count == INTS.Length);
			Assert.That(collectionStr.Count == STRINGS.Length);

			Assert.That(listInt.Count == INTS.Length);
			Assert.That(listStr.Count == STRINGS.Length);
		}

		[Test]
		public void Capacity()
		{
			Assert.That(enumerableInt.Capacity == INTS.Length);
			Assert.That(enumerableStr.Capacity == STRINGS.Length);

			Assert.That(collectionInt.Capacity == INTS.Length);
			Assert.That(collectionStr.Capacity == STRINGS.Length);

			Assert.That(listInt.Capacity == INTS.Length);
			Assert.That(listStr.Capacity == STRINGS.Length);
		}

		#endregion

		#region IEnumerable tests

		[Test]
		public void IEnumerable()
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
		#endregion

		#region ICollection tests

		[Test]
		public void ReadOnlyIsFalse()
		{
			Assert.That(collectionInt.IsReadOnly == false);
			Assert.That(collectionStr.IsReadOnly == false);
		}

		[Test]
		public void Add()
		{
			int[] numbers = new int[INTS.Length + 1];
			int newNumber = 1333;
			for (int i = 0; i < INTS.Length; i++)
			{
				numbers[i] = INTS[i];
			}
			numbers[INTS.Length] = newNumber;

			string[] strings = new string[STRINGS.Length + 1];
			string newString = "Added this one just now";
			for (int i = 0; i < STRINGS.Length; i++)
			{
				strings[i] = STRINGS[i];
			}
			strings[STRINGS.Length] = newString;

			collectionInt.Add(newNumber);
			collectionStr.Add(newString);

			int[] resultNumbers = collectionInt.Select(x => x).ToArray();
			string[] resultStrings = collectionStr.Select(x => x).ToArray();

			Assert.That(collectionInt.Count == INTS.Length + 1);
			Assert.That(collectionStr.Count == STRINGS.Length + 1);

			Assert.That(collectionInt, Is.EqualTo(resultNumbers));
			Assert.That(collectionStr, Is.EqualTo(resultStrings));
		}

		[Test]
		public void Clear()
		{
			collectionInt.Clear();
			Assert.That(collectionInt.Count == 0);
			Assert.That(collectionInt.Capacity == 2);
		}

		[Test, TestCaseSource(nameof(forWhateverReasonIHaveToDeclareThis))]
		public void ContainsInt(int number)
		{
			Assert.That(collectionInt.Contains(number));
		}

		[Test, TestCaseSource(nameof(forWhateverReasonIHaveToDeclareThisToo))]
		public void ContainsString(string item)
		{
			Assert.That(collectionStr.Contains(item));
		}

		[Test]
		public void ContainsIntNotFound()
		{
			Assert.That(collectionInt.Contains(1234321) == false);
		}

		[Test]
		public void ContainsStringNotFound()
		{
			Assert.That(collectionStr.Contains("This shouldn't be in the strings array, yet I am looking for it, huh...") == false);
		}

		[Test]
		public void CopyTo()
		{
			int[] copyInt = new int[collectionInt.Count];
			collectionInt.CopyTo(copyInt, 0);
			Assert.That(copyInt, Is.EqualTo(INTS));

			string[] copyStr = new string[collectionStr.Count];
			collectionStr.CopyTo(copyStr, 0);
			Assert.That(copyStr, Is.EqualTo(STRINGS));

			copyInt = new int[INTS.Length + 1];
			collectionInt.CopyTo(copyInt, 1);
			Assert.That(copyInt[1] == INTS[0]);

			copyStr = new string[STRINGS.Length + 1];
			collectionStr.CopyTo(copyStr, 1);
			Assert.That(copyStr[1] == STRINGS[0]);
		}

		[Test]
		public void CopyToThrows()
		{
			int[] copyInt = new int[collectionInt.Count];
			copyInt = new int[1];
			string[] copyStr = new string[collectionStr.Count];
			copyStr = new string[1];

			collectionInt = new ArrayDynamicICollection<int>(INTS);
			Assert.Throws<IndexOutOfRangeException>(
				() => collectionInt.CopyTo(copyInt, 1),
				LinearDataStructures.ErrorMessages.COPY_ARRAY_TOO_SMALL
			);

			collectionStr = new ArrayDynamicICollection<string>(STRINGS);
			collectionInt = new ArrayDynamicICollection<int>(INTS);
			Assert.Throws<IndexOutOfRangeException>(
				() => collectionStr.CopyTo(copyStr, 1),
				LinearDataStructures.ErrorMessages.COPY_ARRAY_TOO_SMALL
			);
		}

		[Test]
		public void Remove()
		{
			for (int i = 0; i < INTS.Length; i++)
			{
				collectionInt.Remove(INTS[i]);
			}

			Assert.That(collectionInt.Count, Is.EqualTo(0));
			Assert.That(collectionInt.Contains(INTS[1]) == false);
			Assert.That(collectionInt.Remove(123333) == false);
		}
		#endregion

		#region IList tests

		[Test]
		public void IndexerGetValue()
		{
			Assert.That(listInt[0] == INTS[0]);
			Assert.That(listInt[INTS.Length - 1] == INTS[INTS.Length - 1]);
			Assert.Throws<IndexOutOfRangeException>(() => { int a = listInt[INTS.Length]; });
			Assert.Throws<IndexOutOfRangeException>(() => { int a = listInt[-1]; });
		}

		[Test]
		public void IndexerSetValue()
		{
			int newValue = 10000;
			int newEndValue = 10001;
			listInt[0] = newValue;
			Assert.That(listInt[0] == newValue);

			listInt[listInt.Count] = newEndValue;
			Assert.That(listInt[listInt.Count - 1] == newEndValue);
			Assert.That(listInt.Count == INTS.Length + 1);

			Assert.Throws<IndexOutOfRangeException>(() => { listInt[listInt.Count + 1] = newValue; });
			Assert.Throws<IndexOutOfRangeException>(() => { listInt[-1] = newValue; });
		}

		[Test]
		public void Insert()
		{
			int newValue = 10000;
			listInt.Insert(0, newValue);
			Assert.That(listInt[0], Is.EqualTo(newValue));
			Assert.That(listInt.Count, Is.EqualTo(INTS.Length + 1));

			SetUp();
			listInt.Insert(listInt.Count, newValue);
			Assert.That(listInt[listInt.Count - 1], Is.EqualTo(newValue));
			Assert.That(listInt.Count, Is.EqualTo(INTS.Length + 1));

			Assert.Throws<IndexOutOfRangeException>(() => { listInt.Insert(-1, newValue); });
			Assert.Throws<IndexOutOfRangeException>(() => { listInt.Insert(listInt.Count + 1, newValue); });
		}

		[Test]
		public void RemoveAt()
		{
			listInt.RemoveAt(0);
			Assert.That(listInt, Is.Not.Null);
			Assert.That(listInt[0], Is.EqualTo(INTS[1]));

			SetUp();
			listInt.RemoveAt(listInt.Count - 1);
			Assert.That(listInt, Is.Not.Null);
			Assert.That(listInt[listInt.Count - 1], Is.EqualTo(INTS[INTS.Length - 2]));

			Assert.Throws<IndexOutOfRangeException>(() => listInt.RemoveAt(-1));
			Assert.Throws<IndexOutOfRangeException>(() => listInt.RemoveAt(listInt.Count));
		}
		#endregion
	}
}
