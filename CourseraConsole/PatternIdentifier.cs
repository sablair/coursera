using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseraConsole
{
    public class PatternIdentifier
    {
        private readonly ApproximatePatternMatchingCalculator _apm;
        private readonly PatternConverter _patternConverter;
        private readonly NeighborhoodGenerator _ngen;
        private readonly ReverseComplement _rc;

        public PatternIdentifier()
        {
            _apm = new ApproximatePatternMatchingCalculator();
            _patternConverter = new PatternConverter();
            _ngen = new NeighborhoodGenerator();
            _rc = new ReverseComplement();
        }

        public IEnumerable<string> FrequentWordsWithMismatches(string text, int k, int d)
        {
            List<string> frequentPatterns = new List<string>();
            long arrayLength = (long)Math.Pow(4, k);

            var frequencyArray = new int[arrayLength];
            var close = new int[arrayLength];

            for (int i = 0; i <= text.Length - k; i++)
            {
                var neighborhood = _ngen.Neighbors(text.Substring(i, k), d);
                foreach (var pattern in neighborhood)
                {
                    var posIndex = _patternConverter.PatternToNumber(pattern);
                    close[posIndex] = 1;
                }
            }

            for (int index = 0; index < arrayLength; index++)
            {
                if (close[index] == 1)
                {
                    var pattern = _patternConverter.NumberToPattern(index, k);
                    frequencyArray[index] = _apm.ApproximateCount(pattern, text, d) + _apm.ApproximateCount(_rc.Reverse(pattern), text, d);
                }
            }

            int maxCount = frequencyArray.Max();

            for (int index = 0; index < arrayLength; index++)
            {
                if (frequencyArray[index] == maxCount)
                {
                    var pattern = _patternConverter.NumberToPattern(index, k);
                    frequentPatterns.Add(pattern);
                }
            }

            return frequentPatterns;
        }
    }
}
