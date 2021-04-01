public class Solution {
    public int Rob(int[] nums) {
        int RobRange(int[] nums, int start, int end) {
            var n = nums.Length;
            var dp = new int[n + 2];
            for (var i = end; i >= start; i--) dp[i] = Math.Max(dp[i + 1], dp[i + 2] + nums[i]);
            return dp[start];
        }

        var n = nums.Length;
        if (n == 1) return nums[0];
        return Math.Max(RobRange(nums, 1, n - 1), RobRange(nums, 0, n - 2));
    }
}