public class Solution {
    public int MaxScore(int[] cardPoints, int k) {
                int n = cardPoints.Length;
                int windowSize = n - k;
                int sum = 0;
                for (int i = 0; i < windowSize; ++i) {
                    sum += cardPoints[i];
                }
                int minSum = sum;
                for (int i = windowSize; i < n; ++i) {
                    sum += cardPoints[i] - cardPoints[i - windowSize];
                    minSum = Math.Min(minSum, sum);
                }
                return cardPoints.Sum() - minSum;
    }
}