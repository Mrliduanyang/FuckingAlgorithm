public class Solution {
    public int MaxProfit(int[] prices) {
                int n = prices.Length;
                int dp_i_0 = 0, dp_i_1 = int.MinValue;
                for (int i = 0; i < n; i++) { 
                    dp_i_0 = Math.Max(dp_i_0, dp_i_1+ prices[i]);
                    dp_i_1 = Math.Max(dp_i_1, -prices[i]);
                }
                return dp_i_0;
    }
}