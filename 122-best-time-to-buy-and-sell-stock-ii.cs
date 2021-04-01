public class Solution {
    public int MaxProfit(int[] prices) {
                        // 交易次数k=无穷
                int n = prices.Length;
                // 为了避免处理i-1导致的数组越界，将状态压缩
                int dp_i_0 = 0, dp_i_1 = Int32.MinValue;
                for (int i = 0; i < n; i++) {
                    int temp = dp_i_0;
                    dp_i_0 = Math.Max(dp_i_0, dp_i_1 + prices[i]);
                    dp_i_1 = Math.Max(dp_i_1, temp - prices[i]);
                }
                return dp_i_0;
    }
}