public class Solution {
    public bool CanPartition(int[] nums) {
                int sum =  nums.Sum();
                // 如果和是奇数，没法等分，就不存在等和子集
                if (sum % 2 != 0) {
                    return false;
                }
                int n = nums.Length;
                sum = sum / 2;
                // 对于前i个物体，当背包容量为j时，是否可以装满
                bool[, ] dp = new bool[n + 1, sum + 1];
                // base当背包容量为0，肯定已经装满，当没有物体，肯定无法装满
                for (int i = 1; i <= n; i++) {
                    dp[i, 0] = true;
                }
                for (int i = 1; i <= n; i++) {
                    for (int j = 1; j <= sum; j++) {
                        if (j - nums[i - 1] < 0) {
                            // 背包容量不足，不能装入第 i 个物品
                            dp[i, j] = dp[i - 1, j];
                        } else {
                            // 能装，但可以选择装或者不装
                            dp[i, j] = dp[i - 1, j] || dp[i - 1, j - nums[i - 1]];
                        }
                    }
                }
                return dp[n, sum];
    }
}