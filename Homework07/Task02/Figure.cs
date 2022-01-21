using System;
using System.Drawing;

namespace Task02
{
    public abstract class Figure
    {
        protected int _x;
        protected int _y;
        protected Color _color;
        protected bool _visible;

        protected Figure() : this(0, 0, Color.Empty, false) { }

        protected Figure(Color color) : this(0, 0, color, false) { }

        protected Figure(bool visible) : this(0, 0, Color.Empty, visible) { }

        protected Figure(int x, int y) : this(x, y, Color.Empty, false) { }

        protected Figure(int x, int y, Color color) : this(x, y, color, false) { }

        protected Figure(int x, int y, bool visible) : this(x, y, Color.Empty, visible) { }

        protected Figure(int x, int y, Color color, bool visible)
        {
            _x = x;
            _y = y;
            _color = color;
            _visible = visible;
        }

        public int X => _x;

        public int Y => _y;

        public Color Color
        {
            get => _color;
            set => _color = value;
        }

        public bool Visible
        {
            get => _visible;
            set => _visible = value;
        }

        public void MoveX(int offset) => _x += offset;

        public void MoveY(int offset) => _y += offset;

        public virtual void Print()
        {
            Console.WriteLine($"X = {_x}");
            Console.WriteLine($"Y = {_y}");
            Console.WriteLine($"Color = {_color.Name}");
            Console.WriteLine($"Visible = {_visible}");
        }
    }
}
