public class Solution {
    public int FindPoisonedDuration(int[] timeSeries, int duration) {
                int res = 0;
                for (int i = 0; i < timeSeries.Length - 1; i++) {
                    if (timeSeries[i + 1] - timeSeries[i] >= duration) {
                        res += duration;
                    } else {
                        res += (timeSeries[i + 1] - timeSeries[i]);
                    }
                }
                return timeSeries.Length < 1 ? 0 : res + duration;
    }
}