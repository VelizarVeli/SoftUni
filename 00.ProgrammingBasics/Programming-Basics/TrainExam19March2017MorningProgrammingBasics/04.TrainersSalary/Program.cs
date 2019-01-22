using System;

namespace _04.TrainersSalary
{
    class Program
    {
        static void Main()
        {
            int lectires = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int Jelev = 0;
            int RoYal = 0;
            int Roli = 0;
            int Trofon = 0;
            int Sino = 0;
            int Others = 0;
            double perLecture = budget / lectires;

            for (int i = 0; i < lectires; i++)
            {
                string lecturer = Console.ReadLine().ToLower();
                if (lecturer == "jelev")
                {
                    Jelev++;
                }
                else if (lecturer == "royal")
                {
                    RoYal++;
                }
                else if (lecturer == "roli")
                {
                    Roli++;
                }
                else if (lecturer == "trofon")
                {
                    Trofon++;
                }
                else if (lecturer == "sino")
                {
                    Sino++;
                }
                else
                {
                    Others++;
                }
            }
            Console.WriteLine($"Jelev salary: {Jelev * perLecture:f2} lv");
            Console.WriteLine($"RoYaL salary: {RoYal * perLecture:f2} lv");
            Console.WriteLine($"Roli salary: {Roli * perLecture:f2} lv");
            Console.WriteLine($"Trofon salary: {Trofon * perLecture:f2} lv");
            Console.WriteLine($"Sino salary: {Sino * perLecture:f2} lv");
            Console.WriteLine($"Others salary: {Others * perLecture:f2} lv");
        }
    }
}
