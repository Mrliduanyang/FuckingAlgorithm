using System;

public class Solution {
    public int MaxProfit(int[] prices) {
        var n = prices.Length;
        var dp = new int[n + 1, 2 + 1, 2];
        for (var i = 0; i <= n; i++)
        for (var j = 2; j >= 1; j--) {
            if (i - 1 == -1) {
                dp[0, j, 0] = 0;
                dp[0, j, 1] = int.MinValue;
                dp[i, 0, 0] = 0;
                dp[i, 0, 1] = int.MinValue;
                continue;
            }

            dp[i, j, 0] = Math.Max(dp[i - 1, j, 0], dp[i - 1, j, 1] + prices[i - 1]);
            dp[i, j, 1] = Math.Max(dp[i - 1, j, 1], dp[i - 1, j - 1, 0] - prices[i - 1]);
        }

        return dp[n, 2, 0];
    }
}