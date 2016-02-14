using System.Collections.Generic;

namespace CourseraConsole
{
    public class NeighborhoodGenerator
    {
        private readonly HammingDistanceCalculator _hdc;
        public NeighborhoodGenerator()
        {
            _hdc = new HammingDistanceCalculator();
        }

        public IEnumerable<string> Neighbors(string pattern, int d)
        {
            if (d == 0)
            {
                return new string[] { pattern };
            }

            if (pattern.Length == 1)
            {
                return new string[] { "A", "C", "G", "T" };
            }

            var neighborhood = new List<string>();
            var patternSuffix = pattern.Substring(1, pattern.Length - 1);
            var suffixNeighbors = Neighbors(patternSuffix, d);

            foreach (var text in suffixNeighbors)
            {
                if (_hdc.CalculateDistance(patternSuffix, text) < d)
                {
                    neighborhood.Add("A" + text);
                    neighborhood.Add("C" + text);
                    neighborhood.Add("G" + text);
                    neighborhood.Add("T" + text);
                }
                else
                {
                    neighborhood.Add(pattern[0].ToString() + text);
                }
            }
            return neighborhood;
        }
    }
}
