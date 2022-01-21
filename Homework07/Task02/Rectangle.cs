using System;
using System.Drawing;

namespace Task02
{
    public class Rectangle: Point, ITwoDimensional
    {
        private readonly int _width;
        private readonly int _height;

        public Rectangle() : this(0, 0) { }

        public Rectangle(int x, int y) : this(x, y, 1, 1) { }

        public Rectangle(int x, int y, int width, int height) : this(x, y, width, height, Color.Empty, false) { }

        public Rectangle(int x, int y, int width, int height, Color color) : this(x, y, width, height, color, false) { }

        public Rectangle(int x, int y, int width, int height, Color color, bool visible) : base(x, y, color, visible)
        {
            _width = width;
            _height = height;
        }

        public int Width => _width;

        public int Height => _height;

        public double GetArea() => _width * _height;

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Width = {_width}");
            Console.WriteLine($"Height = {_height}");
        }
    }
}
