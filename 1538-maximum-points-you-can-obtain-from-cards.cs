public class Solution {
    public int MaxScore(int[] cardPoints, int k) {
        var n = cardPoints.Length;
        var windowSize = n - k;
        var sum = 0;
        for (var i = 0; i < windowSize; ++i) sum += cardPoints[i];
        var minSum = sum;
        for (var i = windowSize; i < n; ++i) {
            sum += cardPoints[i] - cardPoints[i - windowSize];
            minSum = Math.Min(minSum, sum);
        }

        return cardPoints.Sum() - minSum;
    }
}