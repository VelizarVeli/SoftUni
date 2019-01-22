using System;
using System.Collections.Generic;
using System.Linq;

namespace _13._1.FamilyTree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> relatives = new List<Person>();
            Person mainPerson = new Person();
            string mainPersonInfo = Console.ReadLine();
            if (mainPersonInfo.Contains("/"))
            {
                mainPerson.Birthday = mainPersonInfo;
            }
            else
            {
                mainPerson.Name = mainPersonInfo;
            }

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] hiphenInput = input.Split('-', StringSplitOptions.RemoveEmptyEntries);
                if (hiphenInput.Length == 1)
                {
                    string[] nameBday = input.Split(' ', '-', StringSplitOptions.RemoveEmptyEntries);
                    string name = nameBday[0] + " " + nameBday[1];
                    string birthday = nameBday[2];

                    var currentChild = mainPerson.Children.FirstOrDefault(a => a.Name.Equals(name));
                    var currentparent = mainPerson.Parents.FirstOrDefault(a => a.Name.Equals(name));
                    if (name == mainPerson.Name)
                    {
                        mainPerson.Birthday = birthday;
                    }

                    else if (currentChild != null && currentChild.Name == name)
                    {
                        currentChild.Birthday = birthday;
                    }

                    else if (currentparent != null && currentparent.Name == name)
                    {
                        currentparent.Birthday = birthday;
                    }
                }
                else
                {
                    if (input.Split('/', StringSplitOptions.RemoveEmptyEntries).Length == 0)
                    {
                        string[] parentChild = input.Split(' ', '-', StringSplitOptions.RemoveEmptyEntries);
                        string parent = parentChild[0] + " " + parentChild[1];
                        string child = parentChild[2] + " " + parentChild[3];

                        Person pers = new Person();

                        if (parent == mainPerson.Name)
                        {
                            pers.Name = parent;
                            mainPerson.Children.Add(pers);
                        }
                        else if (child == mainPerson.Name)
                        {
                            pers.Name = child;
                            mainPerson.Parents.Add(pers);
                        }
                        else
                        {
                            relatives.Add(pers);
                        }
                    }
                    else
                    {
                        if (hiphenInput[0].Contains("/") && hiphenInput[1].Contains("/"))
                        {
                            //TODO number 4 = day/month/year - day/month/year
                            string parentDate = hiphenInput[0];
                            string childDate = hiphenInput[1];

                            if (mainPerson.Birthday == parentDate)
                            {
                                mainPerson
                            }

                        }
                        else
                        {
                            if (hiphenInput[0].Contains("/"))
                            {
                                //TODO number 3 - day/month/year - FirstName LastName
                            }
                            else
                            {
                                //TODO number 2 - FirstName LastName - day/month/year
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"{mainPerson.Name} {mainPerson.Birthday}");
            Console.WriteLine("Parents:");
            foreach (var prent in mainPerson.Parents)
            {
                Console.WriteLine($"{prent.Name} {prent.Birthday}");
            }

            Console.WriteLine("Children:");
            foreach (var child in mainPerson.Children)
            {
                Console.WriteLine($"{child.Name} {child.Birthday}");
            }
        }
    }
}
