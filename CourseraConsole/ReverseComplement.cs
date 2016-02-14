using System.Linq;

namespace CourseraConsole
{
    public class ReverseComplement
    {
        public string Reverse(string pattern)
        {
            char[] array = new char[pattern.Length];
            for (int i = 0; i < pattern.Length; i++)
            {
                switch (pattern[i])
                {
                    case 'A':
                        array[i] = 'T';
                        break;
                    case 'C':
                        array[i] = 'G';
                        break;
                    case 'G':
                        array[i] = 'C';
                        break;
                    case 'T':
                        array[i] = 'A';
                        break;
                    default:
                        break;
                }
            }

            return new string(array.Reverse().ToArray());
        }

    }
}
