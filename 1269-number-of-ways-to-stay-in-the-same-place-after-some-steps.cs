using System;

public class Solution {
    public int NumWays(int steps, int arrLen) {
        const int MOD = 1000000007;
        var maxStep = Math.Min(arrLen - 1, steps);
        var dp = new int[steps + 1, maxStep + 1];
        dp[0, 0] = 1;
        for (var i = 1; i <= steps; ++i) {
            for (var j = 0; j <= maxStep; ++j) {
                dp[i, j] = dp[i - 1, j];
                if (j - 1 >= 0) {
                    dp[i, j] = (dp[i, j] + dp[i - 1, j - 1]) % MOD;
                }

                if (j + 1 <= maxStep) {
                    dp[i, j] = (dp[i, j] + dp[i - 1, j + 1]) % MOD;
                }
            }
        }

        return dp[steps, 0];
    }
}