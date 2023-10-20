namespace Bowling
{
    public class Bowling
    {
        public int CalculateScore(string inp)
        {
            string results = inp.Replace(" ", "").Replace("-", "0"); // formatting the frames

            int score = 0;
            int len = results.Length;
            for (int i = 0; i < len; i++)
            {
                // Strike
                if (results[i] == 'X')
                {
                    score += 10;
                    score += ParseScore(results, i + 1);
                    score += ParseScore(results, i + 2);
                    if (i + 3 >= len) break; // if last frame
                }
                // Spare
                else if (results[i] == '/')
                {
                    // sum up self
                    score += 10 - ParseScore(results, i - 1);
                    // add next
                    score += ParseScore(results, i + 1);
                    if (i + 2 >= len) break; // if last frame
                }
                else
                {
                    score += ParseScore(results, i);
                }
            }

            return score;
        }

        private static int ParseScore(string results, int i)
        {
            if (results[i] == 'X') return 10;
            if (results[i] == '/') return 10 - ParseScore(results, i - 1);
            return int.Parse(results[i].ToString());
        }
    }
}