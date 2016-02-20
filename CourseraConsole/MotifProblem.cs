using System.Collections.Generic;
using System.Linq;

namespace CourseraConsole
{
    public class MotifProblem
    {
        private NeighborhoodGenerator _neighborhoodGenerator;
        private ApproximatePatternMatchingCalculator _approximatePatternMatchingCalculator;
        private HammingDistanceCalculator _hammingDistanceCalculator;

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

            kmerArray = kmerHash.ToArray();
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

        public string MedianString(IEnumerable<string> dna, int k)
        {
            _neighborhoodGenerator = new NeighborhoodGenerator();
            string median = string.Empty;
            int distance = int.MaxValue;
            var combinations = new List<string>();

            string As = new string('A', k);
            combinations.AddRange(_neighborhoodGenerator.Neighbors(As, k - 1));
            string Cs = new string('C', k);
            combinations.AddRange(_neighborhoodGenerator.Neighbors(Cs, k - 1));
            string Gs = new string('G', k);
            combinations.AddRange(_neighborhoodGenerator.Neighbors(Gs, k - 1));
            string Ts = new string('T', k);
            combinations.AddRange(_neighborhoodGenerator.Neighbors(Ts, k - 1));

            foreach (var kmer in combinations)
            {
                var calculatedDistance = DistanceBetweenPatternAndStrings(kmer, dna);
                if (distance > calculatedDistance)
                {
                    distance = calculatedDistance;
                    median = kmer;
                }
            }

            return median;
        }

        public int DistanceBetweenPatternAndStrings(string pattern, IEnumerable<string> dna)
        {
            _hammingDistanceCalculator = new HammingDistanceCalculator();
            int k = pattern.Length;
            int distance = 0;

            foreach (var text in dna)
            {
                int hammingDistance = int.MaxValue;
                int dist = 0;
                for (int index = 0; index <= text.Length - k; index++)
                {
                    dist = _hammingDistanceCalculator.CalculateDistance(pattern, text.Substring(index, k));
                    if (hammingDistance > dist)
                    {
                        hammingDistance = dist;
                    }
                }
                distance += hammingDistance;
            }

            return distance;
        }
    }
}
