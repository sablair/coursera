using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseraConsole
{
    public class FrequencyCalculator
    {
        PatternConverter converter;

        public FrequencyCalculator()
        {
            converter = new PatternConverter();
        }

        public IEnumerable<int> ComputingFrequencies(string text, int k)
        {
            long arrayLength = (long)Math.Pow(4, k);
            int[] frequencyArray = new int[arrayLength];

            for (int index = 0; index <= text.Length - k; index++)
            {
                string pattern = text.Substring(index, k);
                long numericRep = converter.PatternToNumber(pattern);
                frequencyArray[numericRep] = frequencyArray[numericRep] + 1;
            }           

            return frequencyArray;
        }
    }
}
