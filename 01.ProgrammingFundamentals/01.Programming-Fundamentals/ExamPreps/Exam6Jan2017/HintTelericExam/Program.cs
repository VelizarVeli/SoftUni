﻿using System;
using System.Numerics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HintTelericExam
{
    class Program
    {
        static void Main(string[] args)
        {
            var hint = new string[]
            {
                "132", "216", "230", "44", "214", "166", "215", "232", "44", "202", "210",
                "205", "210", "224", "223", "44", "202", "216", "203", "223", "44", "224",
                "206", "210", "223", "44", "215", "225", "214", "203", "222", "166", "213",
                "44", "223", "232", "223", "224", "203", "214", "44", "206", "166", "226",
                "203", "120", "44", "133", "223", "44", "224", "206", "203", "222", "203",
                "44", "166", "215", "44", "166", "220", "220", "222", "216", "220", "222",
                "210", "166", "224", "203", "44", "200", "225", "210", "213", "224", "63",
                "210", "215", "44", "204", "225", "215", "201", "224", "210", "216", "215",
                "166", "213", "210", "224", "232", "120", "16", "13", "146", "224", "222",
                "210", "215", "205", "64", "145", "203", "220", "213", "166", "201", "203",
                "44", "201", "166", "215", "44", "223", "210", "214", "220", "213", "210",
                "204", "232", "44", "224", "206", "210", "215", "205", "223", "44", "166",
                "44", "213", "216", "224", "62", "44", "211", "225", "223", "224", "44",
                "200", "203", "44", "201", "166", "222", "203", "204", "225", "213", "44",
                "210", "215", "44", "230", "206", "166", "224", "44", "216", "222", "202",
                "203", "222", "44", "232", "216", "225", "44", "222", "203", "220", "213",
                "166", "201", "203", "16", "13", "150", "206", "210", "215", "212", "44",
                "166", "200", "216", "225", "224", "44", "224", "206", "203", "44", "202",
                "166", "224", "166", "44", "224", "232", "220", "203", "223", "44", "216",
                "204", "44", "224", "206", "203", "44", "224", "206", "222", "203", "203",
                "44", "215", "225", "214", "200", "203", "222", "223", "44", "166", "215",
                "202", "44", "224", "206", "203", "44", "222", "203", "223", "225", "213",
                "224", "44", "63", "44", "206", "216", "230", "44", "214", "225", "201",
                "206", "44", "210", "223", "44", "101", "163", "103", "66", "44", "60",
                "44", "101", "163", "103", "66", "44", "60", "44", "101", "163", "103",
                "66", "44", "60", "44", "101", "163", "103", "66", "120"
            };
            for (int j = 0; j < hint.Length; j++)
            {
                string[] line = hint[j].Trim('"').Split();
                int baseN = int.Parse(line[0]);
                char[] number = line[1].ToCharArray();
                BigInteger result = new BigInteger(0);

                for (int i = number.Length - 1, n = 0; i >= 0; i--, n++)
                {
                    BigInteger num = new BigInteger(char.GetNumericValue(number[n]));
                    BigInteger forSum = BigInteger.Multiply(num, BigInteger.Pow(new BigInteger(baseN), i));
                    result += forSum;
                }

                Console.WriteLine(result.ToString());
            }


            Console.WriteLine(string.Join(" ", hint));



        }
    }
}