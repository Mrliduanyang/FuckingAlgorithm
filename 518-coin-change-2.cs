public class Solution {
    public int Change(int amount, int[] coins) {
                int n = coins.Length;
                int[, ] dp = new int[n + 1, amount + 1];
                // base不用任何硬币，凑不去任何金额，当要凑出0，只有一种方案
                for (int i = 0; i <= n; i++) {
                    dp[i, 0] = 1;
                }
                for (int i = 1; i <= n; i++) {
                    for (int j = 1; j <= amount; j++) {
                        if (j - coins[i - 1] >= 0) {
                            // 目标金额减去当前硬币金额大于硬币金额，可以使用该硬币，也可以不使用
                            dp[i, j] = dp[i - 1, j] + dp[i, j - coins[i - 1]];
                        } else {
                            // 不能使用该硬币
                            dp[i, j] = dp[i - 1, j];
                        }
                    }
                }
                return dp[n, amount];
    }
}