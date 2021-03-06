public class Solution {
    public int Rob(int[] nums) {
        var n = nums.Length;
        // dp定义为从第i间房开始抢劫，最多能抢到的钱
        // base dp[n] = 0
        var dp = new int[n + 2];
        // 从n-1间房开始
        for (var i = n - 1; i >= 0; i--) // 
            dp[i] = Math.Max(dp[i + 1], dp[i + 2] + nums[i]);
        return dp[0];
    }
}