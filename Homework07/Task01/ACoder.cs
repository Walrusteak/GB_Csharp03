using System.Text;

namespace Task01
{
    public class ACoder: ICoder
    {
        public string Encode(string input)
        {
            StringBuilder sb = new(input.Length);
            foreach (char c in input)
            {
                char ec = c switch
                {
                    >= 'A' and <= 'Z' => c == 'A' ? 'Z' : (char)(c - 1),
                    >= 'a' and <= 'z' => c == 'a' ? 'z' : (char)(c - 1),
                    >= 'А' and <= 'Я' => c == 'А' ? 'Я' : (char)(c - 1),
                    >= 'а' and <= 'я' => c == 'а' ? 'я' : (char)(c - 1),
                    _ => c
                };
                sb.Append(ec);
            }
            return sb.ToString();
        }

        public string Decode(string input)
        {
            StringBuilder sb = new(input.Length);
            foreach (char c in input)
            {
                char dc = c switch
                {
                    >= 'A' and <= 'Z' => c == 'Z' ? 'A' : (char)(c + 1),
                    >= 'a' and <= 'z' => c == 'z' ? 'A' : (char)(c + 1),
                    >= 'А' and <= 'Я' => c == 'Я' ? 'А' : (char)(c + 1),
                    >= 'а' and <= 'я' => c == 'я' ? 'а' : (char)(c + 1),
                    _ => c
                };
                sb.Append(dc);
            }
            return sb.ToString();
        }
    }
}
