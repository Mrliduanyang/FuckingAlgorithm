public class Solution {
    public int MaxProfit_2(int[] prices) {
        // 交易次数k=无穷
        var n = prices.Length;
        // 为了避免处理i-1导致的数组越界，将状态压缩
        int dp_i_0 = 0, dp_i_1 = Int32.MinValue;
        for (var i = 0; i < n; i++) {
            var temp = dp_i_0;
            dp_i_0 = Math.Max(dp_i_0, dp_i_1 + prices[i]);
            dp_i_1 = Math.Max(dp_i_1, temp - prices[i]);
        }

        return dp_i_0;
    }

    public int MaxProfit(int k, int[] prices) {
        var n = prices.Length;
        if (k > n / 2)
            return MaxProfit_2(prices);

        var dp = new int[n + 1, k + 1, 2];
        for (var i = 0; i <= n; i++)
        for (var j = k; j >= 1; j--) {
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

        // System.Console.WriteLine(dp[n, k, 0]);
        return dp[n, k, 0];
    }
}