namespace Task01
{
    public struct Complex
    {
        private float _real;
        private float _imaginary;

        public Complex(float real, float imaginary)
        {
            _real = real;
            _imaginary = imaginary;
        }

        public float Real => _real;

        public float Imaginary => _imaginary;

        public override string ToString() => $"{_real} + {_imaginary}i";

        public override bool Equals(object obj)
        {
            if (obj is Complex complex)
                return this == complex;
            return false;
        }

        public override int GetHashCode() => base.GetHashCode() ^ _real.GetHashCode() ^ _imaginary.GetHashCode();

        public static bool operator ==(Complex first, Complex second) => first._real == second._real && first._imaginary == second._imaginary;

        public static bool operator !=(Complex first, Complex second) => !(first == second);

        public static Complex operator +(Complex first, Complex second) => new(first._real + second._real, first._imaginary + second._imaginary);

        public static Complex operator -(Complex first, Complex second) => new(first._real - second._real, first._imaginary - second._imaginary);

        public static Complex operator *(Complex first, Complex second)
        {
            return new(first._real * second._real - first._imaginary * second._imaginary, first._imaginary * second._real + first._real * second._imaginary);
        }

        public static Complex operator /(Complex first, Complex second)
        {
            return new((first._real * second._real + first._imaginary * second._imaginary) / (second._real * second._real + second._imaginary * second._imaginary),
                (first._imaginary * second._real - first._real * second._imaginary) / (second._real * second._real + second._imaginary * second._imaginary));
        }
    }
}
