using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseraConsole
{
    public class ClumpFinder
    {
        FrequencyCalculator _calculator;
        PatternConverter _converter;

        public ClumpFinder()
        {
            _calculator = new FrequencyCalculator();
            _converter = new PatternConverter();
        }

        public IEnumerable<string> BetterClumpFinding(string genome, int k, int t, int L)
        {
            List<string> frequentPatterns = new List<string>();
            long arrayLength = (long)Math.Pow(4, k);
            int[] clump = new int[arrayLength];

            string text = genome.Substring(0, L);
            int[] frequencyArray = _calculator.ComputingFrequencies(text, k).ToArray();
            for (long i = 0; i < arrayLength; i++)
            {
                if (frequencyArray[i] >= t)
                {
                    clump[i] = 1;
                }
            }

            for (int i = 1; i <= genome.Length - L; i++)
            {
                string firstPattern = genome.Substring(i - 1, k);
                long index = _converter.PatternToNumber(firstPattern);
                frequencyArray[index] = frequencyArray[index] - 1;
                string lastPattern = genome.Substring(i + L - k, k);
                index = _converter.PatternToNumber(lastPattern);
                frequencyArray[index] = frequencyArray[index] + 1;
                if (frequencyArray[index] >= t)
                {
                    clump[index] = 1;
                }
            }

            for (long i = 0; i < arrayLength; i++)
            {
                if (clump[i] == 1)
                {
                    string pattern = _converter.NumberToPattern(i, k);
                    frequentPatterns.Add(pattern);
                }
            }

            return frequentPatterns;
        }
    }
}
