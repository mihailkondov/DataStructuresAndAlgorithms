using System.Text;
using DataStructures.LinearDataStructures.Stack;

namespace DataStructures.Demos
{
    internal class StackDemo : IDemoRunable
    {
        string expression = "12 - sqrt( 12 * (1 + 2) / 2 - (1 + 3))";
        StackStatic<string> expressionsStack = new StackStatic<string>();

        StackStatic<int> expressionStarts = new StackStatic<int>();

        public void Run()
        {
            Console.WriteLine("S T A R T I N G   Stack Demo");
            Console.WriteLine($"The subexpressions of the expression \"{expression}\" are:");

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    expressionStarts.Push(i);
                }
                else if (expression[i] == ')')
                {
					StringBuilder sb = new StringBuilder();

					for (int j = expressionStarts.Pop(); j <= i; j++)
                    {
                        sb.Append(expression[j]);
                    }

                    expressionsStack.Push(sb.ToString());
                }
            }

            while (expressionsStack.Count > 0)
            {
                Console.WriteLine(expressionsStack.Pop());
            }

            Console.WriteLine("F I N I S H E D   Stack demo");
            Console.WriteLine();
        }
    }
}
