namespace Shuffle
{
    public static class ShuffleRangeArray
    {
        /// <summary>
        /// Generates a random array of given length without repeating numbers. 
        /// Works by generating random numbers and adding them to the resulting array as long as they are not repeating, until the given length is reached.
        /// </summary>
        /// <param name="len"></param>
        /// <returns></returns>
        public static int[] DrawCheckRedraw(int len)
        {
            Random random = new Random();
            int[] numbers = new int[len];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next() % len + 1; // Draw current number

                for (int j = 0; j < i; j++) // Check it is a repeat
                {
                    if (numbers[j] == numbers[i])
                    {
                        numbers[i] = random.Next() % len + 1;
                        j = -1; // reset loop
                    }
                }
            }
            return numbers;
        }

        /// <summary>
        /// Generates a random array of given length without repeating numbers. 
        /// Works by generating a list of numbers from 1 to the required length and then each element from the list is selected at random and added to another list which is then returned as an array.
        /// </summary>
        /// <param name="len"></param>
        /// <returns></returns>
        public static int[] MoveLists(int len)
        {
            Random random = new Random();
            List<int> numbers = Enumerable.Range(1, 4).ToList();
            List<int> shuffled = new List<int>();
            do
            {
                int current = random.Next(0, numbers.Count());
                shuffled.Add(numbers[current]);
                numbers.RemoveAt(current);
            } while (numbers.Count > 0);

            return shuffled.ToArray();
        }

        /// <summary>
        /// Generates a random array of given length without repeating numbers. 
        /// Works by creating an array with the numbers from 1 to the required length and then shuffling them with the Modern Fisher-Yates algorithm.
        /// </summary>
        /// <param name="len"></param>
        /// <returns></returns>
        public static int[] FisherYates(int len)
        {
            int[] numbers = Enumerable.Range(1, len).ToArray();
            Random random = new Random();

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int rnd = random.Next(i, numbers.Length);
                int tmp = numbers[i];
                numbers[i] = numbers[rnd];
                numbers[rnd] = tmp;
            }

            return numbers;
        }
    }
}
