using System;
using System.Collections.Generic;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            List<IShape> shapes = new List<IShape>();

            var shape = new Rectangle();
            shapes.Add(shape);
            var shape1 = new Circle();
            shapes.Add(shape1);
            var shape2 = new Square();
            shapes.Add(shape2);
            var shape3 = new Circle();
            shapes.Add(shape3);
            var shape4 = new Rectangle();
            shapes.Add(shape4);

            foreach (var shapein in shapes)
            {
                shapein.Draw();
            }
        }
    }
}
