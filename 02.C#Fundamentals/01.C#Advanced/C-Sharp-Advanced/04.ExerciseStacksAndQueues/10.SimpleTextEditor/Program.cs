using System;
using System.Collections.Generic;
using System.Linq;
//30/100

namespace _10.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            string myOne = String.Empty;
            Stack<string> comman = new Stack<string>();
            for (int i = 0; i < N; i++)
            {
                string commandes = Console.ReadLine();
                string commanda = commandes.Substring(0, 1);
                if (commanda == "1")
                {
                    string command = commandes.Substring(2);
                    myOne += command;
                    comman.Push(commandes);
                }
                else if (commanda == "2")
                {
                    string command = commandes.Substring(2);
                    int comm = int.Parse(command);
                    myOne = myOne.Substring(0, myOne.Length - comm);
                    comman.Push(commandes);
                }
                else if (commanda == "3")
                {
                    string command = commandes.Substring(2);
                    int comm = int.Parse(command);
                    char co = myOne[comm - 1];
                    Console.WriteLine(co);
                }
                else if (commanda == "4")
                {
                    string popi = comman.Pop();
                    string comerad = popi.Substring(0, 1);
                    string comrade = popi.Substring(2);

                    if (comerad == "1")
                    {
                        myOne = myOne.Substring(0, myOne.Length - comrade.Length);
                    }
                    else if (comerad == "2")
                    {
                        popi = comman.Pop();
                        comrade = popi.Substring(2);
                        myOne += comrade;
                    }
                }
            }
        }
    }
}
