using System;
using System.Collections.Generic;
using System.Linq;

class Startup
{
    static void Main()
    {
        var boxes = new List<Box<string>>();

        var boxesCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < boxesCount; i++)
        {
            var boxContent = Console.ReadLine();
            var box = new Box<string>(boxContent);
            boxes.Add(box);
        }

        var indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var i1 = indexes[0];
        var i2 = indexes[1];

        SwapElements(boxes, i1, i2);

        boxes.ForEach(b => Console.WriteLine(b));
    }

    static void SwapElements<T>(List<T> boxes, int i1, int i2)
    {
        var temp = boxes[i1];
        boxes[i1] = boxes[i2];
        boxes[i2] = temp;
    }
}