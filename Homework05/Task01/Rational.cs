using System;
namespace Task01
{
    public struct Rational
    {
        private int _numerator;
        private int _denominator;

        public Rational(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Denominator can not be zero");
            _numerator = numerator;
            _denominator = denominator;
        }

        public int Numerator => _numerator;

        public int Denominator => _denominator;

        public override string ToString() => $"{_numerator}/{_denominator}";

        public override bool Equals(object obj)
        {
            if (obj is Rational rational)
                return this == rational;
            return false;
        }

        public override int GetHashCode() => base.GetHashCode() ^ _numerator.GetHashCode() ^ _denominator.GetHashCode();

        public static bool operator ==(Rational first, Rational second)
        {
            if (first._denominator == second._denominator)
                return first._numerator == second._numerator;
            return first._numerator * second._denominator == second._numerator * first._denominator;
        }

        public static bool operator !=(Rational first, Rational second) => !(first == second);

        public static bool operator <(Rational first, Rational second)
        {
            if (first._denominator == second._denominator)
                return first._numerator < second._numerator;
            return first._numerator * second._denominator < second._numerator * first._denominator;
        }

        public static bool operator >(Rational first, Rational second)
        {
            if (first._denominator == second._denominator)
                return first._numerator > second._numerator;
            return first._numerator * second._denominator > second._numerator * first._denominator;
        }

        public static bool operator <=(Rational first, Rational second) => !(first > second);

        public static bool operator >=(Rational first, Rational second) => !(first < second);

        public static Rational operator +(Rational first, Rational second)
        {
            if (first._denominator == second._denominator)
                return new(first._numerator + second._numerator, first._denominator);
            return new(first._numerator * second._denominator + second._numerator * first._denominator, first._denominator * second._denominator);
        }

        public static Rational operator -(Rational first, Rational second)
        {
            if (first._denominator == second._denominator)
                return new(first._numerator - second._numerator, first._denominator);
            return new(first._numerator * second._denominator - second._numerator * first._denominator, first._denominator * second._denominator);
        }

        public static Rational operator *(Rational first, Rational second) => new(first._numerator * second._numerator, first._denominator * second._denominator);

        public static Rational operator /(Rational first, Rational second) => new(first._numerator * second._denominator, first._denominator * second._numerator);

        public static int operator %(Rational first, Rational second) => (int)((float)first % second);

        public static Rational operator ++(Rational rational)
        {
            rational._numerator++;
            return rational;
        }

        public static Rational operator --(Rational rational)
        {
            rational._numerator--;
            return rational;
        }

        public static implicit operator float(Rational rational) => (float)rational._numerator / rational._denominator;

        public static explicit operator int(Rational rational) => rational._numerator / rational._denominator;
    }
}
