using System;
using System.Drawing;

namespace Task02
{
    public class Circle: Point
    {
        private readonly int _radius;

        public Circle() : this(0, 0) { }

        public Circle(int x, int y) : this(x, y, 1) { }
        
        public Circle(int x, int y, int radius) : this(x, y, radius, Color.Empty, false) { }

        public Circle(int x, int y, int radius, Color color) : this(x, y, radius, color, false) { }

        public Circle(int x, int y, int radius, Color color, bool visible) : base(x, y, color, visible)
        {
            _radius = radius;
        }

        public int Radius => _radius;

        public double GetArea() => Math.PI * _radius * _radius;

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Radius = {_radius}");
        }
    }
}
