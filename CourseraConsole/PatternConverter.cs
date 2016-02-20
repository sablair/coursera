using System;

namespace CourseraConsole
{
    public class PatternConverter
    {
        public string NumberToPattern(long index, int k)
        {
            if (k == 1)
            {
                return NumberToSymbol(index);
            }

            long prefixIndex = index / 4;
            long remainder = index % 4;

            string symbol = NumberToSymbol(remainder);
            string prefixPattern = NumberToPattern(prefixIndex, k - 1);

            return prefixPattern + symbol;
        }

        public string NumberToSymbol(long index)
        {
            switch (index)
            {
                case 0:
                    return "A";
                case 1:
                    return "C";
                case 2:
                    return "G";
                case 3:
                    return "T";
                default:
                    throw new Exception("Invalid numeric representation");
            }
        }

        public long PatternToNumber(string pattern)
        {
            if (string.IsNullOrEmpty(pattern))
            {
                return 0;
            }

            char symbol = pattern[pattern.Length - 1];
            string prefix = pattern.Substring(0, pattern.Length - 1);

            return 4 * PatternToNumber(prefix) + SymbolToNumber(symbol);
        }

        public int SymbolToNumber(char symbol)
        {
            switch (symbol)
            {
                case 'A':
                    return 0;
                case 'C':
                    return 1;
                case 'G':
                    return 2;
                case 'T':
                    return 3;
                default:
                    throw new Exception("Invalid symbol found in genome string");                    
            }
        }
    }
}
