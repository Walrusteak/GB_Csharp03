using System.Drawing;

namespace Task02
{
    public class Point: Figure
    {
        public Point() { }

        public Point(Color color) : base(color) { }

        public Point(bool visible) : base(visible) { }

        public Point(int x, int y) : base(x, y) { }

        public Point(int x, int y, Color color) : base(x, y, color) { }

        public Point(int x, int y, bool visible) : base(x, y, visible) { }

        public Point(int x, int y, Color color, bool visible) : base(x, y, color, visible) { }
    }
}
