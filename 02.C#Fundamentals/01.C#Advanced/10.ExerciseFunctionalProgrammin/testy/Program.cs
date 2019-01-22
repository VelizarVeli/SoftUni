using System;

namespace Rounding
    
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] nums= new double[]{};
            int[] arr = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                arr[i] = (int)Math.Round(nums[i], MidpointRounding.AwayFromZero);
            }
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine($"{nums[i]} => {arr[i]}");
            }
        }
    }
}