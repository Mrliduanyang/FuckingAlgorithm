public class Solution {
    public int MaxProfit(int[] prices, int fee) {
        var n = prices.Length;
        int dp_i_0 = 0, dp_i_1 = Int32.MinValue;
        for (var i = 0; i < n; i++) {
            var temp = dp_i_0;
            dp_i_0 = Math.Max(dp_i_0, dp_i_1 + prices[i]);
            dp_i_1 = Math.Max(dp_i_1, temp - prices[i] - fee);
        }

        return dp_i_0;
    }
}