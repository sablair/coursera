using System.Collections.Generic;
using System.Linq;

namespace CourseraConsole
{
    public class ProfileMostProbableKmerProblem
    {
        private IEnumerable<string> ExtractKmers(string dna, int k)
        {
            var result = new HashSet<string>();
            for (int index = 0; index <= dna.Length - k; index++)
            {
                result.Add(dna.Substring(index, k));
            }

            return result;
        }

        public string Solve(string dna, int k, double[,] profile)
        {
            PatternConverter patternConverter = new PatternConverter();
            var kmers = ExtractKmers(dna, k).ToList();
            double maxProbability = 0;
            int maxIndex = -1;

            for (var row = 0; row < kmers.Count; row++)
            {
                string kmer = kmers[row];
                double product = 1;
                for (int index = 0; index < kmer.Length; index++)
                {
                    product *= profile[patternConverter.SymbolToNumber(kmer[index]), index];
                }

                if (maxProbability < product)
                {
                    maxProbability = product;
                    maxIndex = row;
                }                
            }

            return kmers[maxIndex];
        }
    }
}
