﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml;
using LinearDataStructures.Stack;

namespace LinearDataStructures.Demos
{
    internal class StackDemo : IRunable
    {
        string expression = "12 - sqrt( 12 * (1 + 2) / 2 - (1 + 3))";
        StaticStack<string> expressionsStack = new StaticStack<string>();

        StaticStack<int> expressionStarts = new StaticStack<int>();

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
