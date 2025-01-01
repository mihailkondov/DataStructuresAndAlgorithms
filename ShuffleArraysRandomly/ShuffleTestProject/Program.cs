using static Shuffle.ShuffleRangeArray;

namespace ShuffleTestProject
{
    /// <summary>
    /// This tests different methods of permutating the number sequences by testing with a sequence of four.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Shuffle my first attempt:");
            TestShuffleFour(DrawCheckRedraw);

            Console.WriteLine("Shuffle my second attempt:");
            TestShuffleFour(MoveLists);

            Console.WriteLine("Fischer-Yates shuffle method:");
            TestShuffleFour(FisherYates);
        }

        private static void TestShuffleFour(Func<int, int[]> shuffleFunction)
        {
            Dictionary<string, int> statistic = new Dictionary<string, int>() {
                { "1,2,3,4", 0 }
            ,   { "1,2,4,3", 0 }
            ,   { "1,3,2,4", 0 }
            ,   { "1,3,4,2", 0 }
            ,   { "1,4,2,3", 0 }
            ,   { "1,4,3,2", 0 }
            ,   { "2,1,3,4", 0 }
            ,   { "2,1,4,3", 0 }
            ,   { "2,3,1,4", 0 }
            ,   { "2,3,4,1", 0 }
            ,   { "2,4,1,3", 0 }
            ,   { "2,4,3,1", 0 }
            ,   { "3,1,2,4", 0 }
            ,   { "3,1,4,2", 0 }
            ,   { "3,2,1,4", 0 }
            ,   { "3,2,4,1", 0 }
            ,   { "3,4,1,2", 0 }
            ,   { "3,4,2,1", 0 }
            ,   { "4,1,2,3", 0 }
            ,   { "4,1,3,2", 0 }
            ,   { "4,2,1,3", 0 }
            ,   { "4,2,3,1", 0 }
            ,   { "4,3,1,2", 0 }
            ,   { "4,3,2,1", 0 }
            };

            int probes = 10000;
            int expected = probes / statistic.Count;

            for (int i = 0; i < probes; i++)
            {
                int[] numbers = shuffleFunction(4);
                string result = string.Join(",", numbers);
                statistic[result]++;
            }

            Console.WriteLine($"Expected count: {expected}");
            Console.WriteLine();
            foreach (KeyValuePair<string, int> kvp in statistic)
            {
                int deviation = kvp.Value - expected;
                Console.WriteLine(kvp.Key + ":\t" + kvp.Value + "\t" + "Deviation from expected: " + deviation);
            }
            Console.WriteLine();
        }
    }
}
