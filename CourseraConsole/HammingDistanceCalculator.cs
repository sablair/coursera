namespace CourseraConsole
{
    public class HammingDistanceCalculator
    {
        public int CalculateDistance(string sequence1, string sequence2)
        {
            int distance = 0;

            for (int index = 0; index < sequence1.Length; index++)
            {
                if (sequence1[index] != sequence2[index])
                {
                    distance++;
                }
            }
            return distance;
        }
    }
}
