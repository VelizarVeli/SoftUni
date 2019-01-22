using System;
using System.Collections.Generic;

namespace _05._1.BorderControl
{
    class Program
    {
        static void Main()
        {
            List<IBirthable> birthdates = new List<IBirthable>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inp = input.Split();
                string national = inp[0];

                if (national == "Robot")
                {
                }

                else if (national == "Citizen")
                {
                    string name = inp[1];
                    int age = int.Parse(inp[2]);
                    string id = inp[3];
                    string birthdate = inp[4];

                    Citizen citizen = new Citizen(name, age,birthdate);
                    birthdates.Add(citizen);
                }

                else if (national == "Pet")
                {
                    string name = inp[1];
                    string birthdate = inp[2];

                    Pet pet = new Pet(name, birthdate);
                    birthdates.Add(pet);
                }
            }

            string year = Console.ReadLine();

            foreach (var birthday in birthdates)
            {
                string check = birthday.Birthdate.Substring(birthday.Birthdate.Length - 4);

                if (check == year)
                {
                    Console.WriteLine(birthday.Birthdate);
                }
            }
        }
    }
}
