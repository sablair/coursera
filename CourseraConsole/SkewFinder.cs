using System.Collections.Generic;

namespace CourseraConsole
{
    public class SkewFinder
    {
        public IEnumerable<int> GetMinimumSkewPoints(string dnaSequence)
        {
            var result = new List<int>();
            var skew = 0;
            var min = int.MaxValue;
            for(var index = 0; index < dnaSequence.Length; index++)
            {
                var nucleotide = dnaSequence[index];
                switch (nucleotide)
                {
                    case 'G':
                        skew++;
                        break;
                    case 'C':
                        skew--;
                        break;
                    default:
                        break;
                }

                if (skew <= min)
                {
                    if (skew < min)
                    {
                        result.Clear();
                    }
                    min = skew;
                    result.Add(index + 1);
                }
            }
            return result;
        }

        public IEnumerable<int> GetMaximumSkewPoints(string dnaSequence)
        {
            var result = new List<int>();
            var skew = 0;
            var max = int.MinValue;
            for (var index = 0; index < dnaSequence.Length; index++)
            {
                var nucleotide = dnaSequence[index];
                switch (nucleotide)
                {
                    case 'G':
                        skew++;
                        break;
                    case 'C':
                        skew--;
                        break;
                    default:
                        break;
                }

                if (skew >= max)
                {
                    if (skew > max)
                    {
                        result.Clear();
                    }
                    max = skew;
                    result.Add(index + 1);
                }
            }
            return result;
        }

    }
}
