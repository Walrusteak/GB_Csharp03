using System;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            ACoder aCoder = new();
            string str = "Привет, мир! Арбуз, яблоко. 12345";
            string encoded = aCoder.Encode(str);
            string decoded = aCoder.Decode(encoded);
            Console.WriteLine($"Строка: {str}");
            Console.WriteLine($"Зашифровано: {encoded}");
            Console.WriteLine($"Расшифровано: {decoded}");
            Console.WriteLine();

            BCoder bCoder = new();
            str = "А я шифрую. QaZwSx";
            encoded = bCoder.Encode(str);
            decoded = bCoder.Decode(encoded);
            Console.WriteLine($"Строка: {str}");
            Console.WriteLine($"Зашифровано: {encoded}");
            Console.WriteLine($"Расшифровано: {decoded}");
        }
    }
}
