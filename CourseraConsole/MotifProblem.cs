using System.Collections.Generic;
using System.Linq;

namespace CourseraConsole
{
    public class MotifProblem
    {
        private NeighborhoodGenerator _neighborhoodGenerator;
        private ApproximatePatternMatchingCalculator _approximatePatternMatchingCalculator;

        public IEnumerable<string> MotifEnumeration(IEnumerable<string> dnaSequences, int k, int d)
        {
            _neighborhoodGenerator = new NeighborhoodGenerator();
            _approximatePatternMatchingCalculator = new ApproximatePatternMatchingCalculator();
            var kmerHash = ExtractKmers(dnaSequences, k);
            var kmerArray = kmerHash.ToArray();
            var results = new HashSet<string>();

            foreach (var kmer in kmerArray)
            {
                IEnumerable<string> neighbors = _neighborhoodGenerator.Neighbors(kmer, d);
                foreach (var n in neighbors)
                {
                    kmerHash.Add(n);
                }
            }
                        
            foreach (var kmer in kmerArray)
            {
                int count = 0;
                foreach (var sequence in dnaSequences)
                {
                    if (_approximatePatternMatchingCalculator.ApproximateCount(kmer, sequence, d) > 0)
                    {                        
                        count++;
                    }
                }

                if (count == dnaSequences.Count())
                {
                    results.Add(kmer);
                }
            }           

            return results.ToArray();
        }

        private HashSet<string> ExtractKmers(IEnumerable<string> dna, int k)
        {
            var result = new HashSet<string>();
            foreach (var sequence in dna)
            {
                for (int index = 0; index <= sequence.Length - k; index++)
                {
                    result.Add(sequence.Substring(index, k));
                }
            }

            return result;
        }
    }
}
