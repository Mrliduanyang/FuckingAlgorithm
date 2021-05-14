public class Solution {
    public int WaysToChange(int n) {
        const int MOD = 1000000007;
        var coins = new[] {1, 5, 10, 25};
        var dp = new int[n + 1];
        dp[0] = 1;
        foreach (var coin in coins) {
            for (var i = coin; i <= n; ++i) {
                dp[i] = (dp[i] + dp[i - coin]) % MOD;
            }
        }

        return dp[n];
    }
}