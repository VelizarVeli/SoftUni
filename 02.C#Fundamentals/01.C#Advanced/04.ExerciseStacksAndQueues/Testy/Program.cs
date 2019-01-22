using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.__Poisonous_Plants
{
    class Program
    {
        static void Main()
        {
            int numberPlants = int.Parse(Console.ReadLine());

            List<long> posAndAmountPestPlant = Console.ReadLine().Split(' ').Select(long.Parse).ToList();

            int lastDeadDay = 0;
            int dayCounter = 0;

            List<long> listOfPlants = new List<long>(posAndAmountPestPlant);

            while (true) // Day Counting;
            {
                dayCounter++;

                int diedThisDay = 0;

                for (int j = 0; j < posAndAmountPestPlant.Count - 1; j++) // Checking each plant;
                {
                    if (posAndAmountPestPlant[j + 1] > posAndAmountPestPlant[j])
                    {
                        long DeadPlant = posAndAmountPestPlant[j + 1];
                        int indexOf = listOfPlants.LastIndexOf(DeadPlant);
                        listOfPlants.RemoveAt(indexOf);

                        lastDeadDay = dayCounter;
                        diedThisDay = 1;
                    }
                }

                posAndAmountPestPlant = listOfPlants;

                if (diedThisDay == 0)
                {
                    Console.WriteLine(lastDeadDay);
                    return;
                }
            }
        }
    }
}