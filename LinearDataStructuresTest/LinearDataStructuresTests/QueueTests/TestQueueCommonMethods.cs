namespace Tests.LinearDataStructuresTests.QueueTests
{
    public class TestQueueCommonMethods
    {

        /// <summary>
        /// Compares two arrays of strings character by character for each string. 
        /// </summary>
        /// <param name="a">string array to compare</param>
        /// <param name="b">string array to compare</param>
        /// <returns></returns>
        protected bool EqualsCompareStringArraysByValue(string[] a, string[] b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }

            for (int i = 0; i < a.Length; i++)
            {
                if (string.Compare(a[i], b[i]) != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}