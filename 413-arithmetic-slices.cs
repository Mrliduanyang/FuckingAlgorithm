public class Solution {
    public int NumberOfArithmeticSlices(int[] A) {
        var dp = new int[A.Length];
        var sum = 0;
        for (var i = 2; i < dp.Length; i++)
            if (A[i] - A[i - 1] == A[i - 1] - A[i - 2]) {
                dp[i] = 1 + dp[i - 1];
                sum += dp[i];
            }

        return sum;
    }
}