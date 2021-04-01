public class Solution {
    public int IntegerBreak(int n) {
        var dp = new int[n + 1];
        for (var i = 2; i <= n; i++) {
            var curMax = 0;
            for (var j = 1; j < i; j++) curMax = Math.Max(curMax, Math.Max(j * (i - j), j * dp[i - j]));
            dp[i] = curMax;
        }

        return dp[n];
    }
}