using System.Collections.Generic;

namespace CourseraConsole
{
    public class ApproximatePatternMatchingCalculator
    {
        private readonly HammingDistanceCalculator _hdc;
        public ApproximatePatternMatchingCalculator()
        {
            _hdc = new HammingDistanceCalculator();
        }

        public IEnumerable<int> MakeApproximations(string pattern, string text, int mismatches)
        {
            var values = new List<int>();
            for (int index = 0; index <= text.Length - pattern.Length; index++)
            {
                if (_hdc.CalculateDistance(pattern, text.Substring(index, pattern.Length)) <= mismatches)
                {
                    values.Add(index);
                }
            }
            return values;
        }
    }
}
