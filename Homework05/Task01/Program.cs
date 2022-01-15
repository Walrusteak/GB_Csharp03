using static System.Console;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            Rational r1 = new(1, 2);
            r1++;
            WriteLine(r1);
            r1++;
            WriteLine(r1);
            r1--;
            WriteLine(r1);

            Rational r2 = r1 + new Rational(2, 3);
            WriteLine(r2);
            Rational r3 = r1 + new Rational(4, 2);
            WriteLine(r3);

            int n = new Rational(10, 2) % new Rational(9, 3);
            WriteLine(n);

            WriteLine(new Rational(1, 2) == new Rational(5, 10));
            WriteLine();

            Complex c1 = new(1, 2);
            WriteLine(c1);
            Complex c2 = new(3, 4);
            WriteLine(c2);
            Complex c3 = c1 + c2;
            WriteLine(c3);
            Complex c4 = c1 - c2;
            WriteLine(c4);
            Complex c5 = c1 * c2;
            WriteLine(c5);
            Complex c6 = c1 / c2;
            WriteLine(c6);
            WriteLine(new Complex(5, 5) == new Complex(5, 5));
        }
    }
}
