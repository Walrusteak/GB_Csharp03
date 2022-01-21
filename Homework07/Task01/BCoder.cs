using System.Text;

namespace Task01
{
    public class BCoder : ICoder
    {
        public string Encode(string input)
        {
            StringBuilder sb = new(input.Length);
            foreach (char c in input)
            {
                char ec = c switch
                {
                    >= 'A' and <= 'Z' => (char)('A' + 'Z' - c),
                    >= 'a' and <= 'z' => (char)('a' + 'z' - c),
                    >= 'А' and <= 'Я' => (char)('А' + 'Я' - c),
                    >= 'а' and <= 'я' => (char)('а' + 'я' - c),
                    _ => c
                };
                sb.Append(ec);
            }
            return sb.ToString();
        }

        public string Decode(string input) => Encode(input);
    }
}
