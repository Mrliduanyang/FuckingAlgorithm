public class Solution {
    public int NumSquares(int n) {
        // 跟换硬币差不多，把硬币换成完全平方数，并且不限制硬币个数
        var nums = new List<int>();
        for (var i = 1; i * i <= n; i++) nums.Add(i * i);
        var dp = new int[n + 1];
        Array.Fill(dp, n + 1);
        dp[0] = 0;
        for (var i = 1; i <= n; i++)
            foreach (var num in nums) {
                if (i - num < 0) continue;
                dp[i] = Math.Min(dp[i], 1 + dp[i - num]);
            }

        return dp[n];
    }
}