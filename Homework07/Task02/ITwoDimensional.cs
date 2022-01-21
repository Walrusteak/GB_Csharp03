namespace Task02
{
    public interface ITwoDimensional
    {
        int X { get; }
        int Y { get; }

        void MoveX(int offset);
        void MoveY(int offset);
        double GetArea();
    }
}
