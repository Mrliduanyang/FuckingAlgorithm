public class Solution {
    public int FindNumberOfLIS(int[] nums) {
int[] dp = new int[nums.Length];
                int[] counter = new int[nums.Length];
                Array.Fill(dp, 1);
                Array.Fill(counter, 1);
                int max = -1;
                for (int i = 0; i < nums.Length; i++) {
                    for (int j = 0; j < i; j++) {
                        if (nums[i] > nums[j]) {
                            if (dp[j] + 1 > dp[i]) {
                                dp[i] = Math.Max(dp[i], dp[j] + 1);
                                counter[i] = counter[j];
                            } else if (dp[j] + 1 == dp[i]) {
                                counter[i] += counter[j];

                            }
                        }
                    }
                    max = Math.Max(max, dp[i]);
                }
                int res = 0;
                for (int i = 0; i < nums.Length; i++) {
                    if (dp[i] == max)
                        res += counter[i];
                }

                return res;
    }
}