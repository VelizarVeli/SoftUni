using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            Stack<char> brackets = new Stack<char>();
            bool check = true;

            if (input.Length % 2 == 1)
            {
                Console.WriteLine("NO");
                return;
            }

            for (int i = 0; i < input.Length; i++)
            {

                char bracket = input[i];
                if (i == 0 && bracket != '{' && bracket != '(' && bracket != '[')
                {
                    Console.WriteLine("NO");
                    check = false;
                    break;
                }
                if (bracket == '(' || bracket == '{' || bracket == '[')
                {
                    brackets.Push(bracket);
                }
                else
                {
                    if (bracket == ')')
                    {
                        char checky = brackets.Peek();
                        if (checky == '(')
                        {
                            brackets.Pop();
                        }
                        else
                        {
                            Console.WriteLine("NO");
                            check = false;
                            break;
                        }
                    }
                    else if (bracket == '}')
                    {
                        char checky = brackets.Peek();
                        if (checky == '{')
                        {
                            brackets.Pop();
                        }
                        else
                        {
                            Console.WriteLine("NO");
                            check = false;
                            break;
                        }
                    }
                    else if (bracket == ']')
                    {
                        char checky = brackets.Peek();
                        if (checky == '[')
                        {
                            brackets.Pop();
                        }
                        else
                        {
                            Console.WriteLine("NO");
                            check = false;
                            break;
                        }
                    }
                }
            }
            if (check)
            {
                Console.WriteLine("YES");
            }
        }
    }
}
