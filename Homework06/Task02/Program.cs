using System;
using System.Drawing;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new();
            circle.Print();
            Console.WriteLine();
            Rectangle rectangle = new Rectangle(1, 2, 3, 4, Color.PeachPuff, true);
            rectangle.Print();
            Console.WriteLine();
            rectangle.Color = Color.Salmon;
            rectangle.MoveX(10);
            rectangle.MoveY(-5);
            rectangle.Print();
        }
    }
}
