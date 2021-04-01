public class Solution {
    public int LengthOfLIS(int[] nums) {
                int[] dp = new int[nums.Length];
                // base， 以nums[i]结尾的最长递增子序列起码包含自己
                Array.Fill(dp, 1);
                // 找到前面比nums[i]小的元素，将nums[i]加在该元素后面，并将长度+1
                for (int i = 0; i < nums.Length; i++) {
                    for (int j = 0; j < i; j++) {
                        if (nums[i] > nums[j]) {
                            dp[i] = Math.Max(dp[i], dp[j] + 1);
                        }
                    }
                }
                return dp.Max();
    }
}