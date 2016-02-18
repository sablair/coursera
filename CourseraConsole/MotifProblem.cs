using System.Collections.Generic;
using System.Linq;

namespace CourseraConsole
{
    public class MotifProblem
    {
        private NeighborhoodGenerator _neighborhoodGenerator;
        private ApproximatePatternMatchingCalculator _approximatePatternMatchingCalculator;

        public IEnumerable<string> MotifEnumeration(IEnumerable<string> dna, int k, int d)
        {
            _neighborhoodGenerator = new NeighborhoodGenerator();
            _approximatePatternMatchingCalculator = new ApproximatePatternMatchingCalculator();
            HashSet<string> result = new HashSet<string>();

            foreach (var sequence in dna)
            {
                foreach (var kmer in ExtractKmers(sequence, k).ToArray())
                {
                    IEnumerable<string> neighbors = _neighborhoodGenerator.Neighbors(kmer, d);
                    foreach (var n in neighbors)
                    {
                        if (_approximatePatternMatchingCalculator.ApproximateCount(n, sequence, d) > 0)
                        {
                            result.Add(n);
                        }
                    }
                }
            }
            
            var patterns = new List<string>();


            return patterns;
        }

        private HashSet<string> ExtractKmers(string dna, int k)
        {
            var result = new HashSet<string>();
            for (int index = 0; index <= dna.Length - k; index++)
            {
                result.Add(dna.Substring(index, k));
            }

            return result;
        }
    }
}
