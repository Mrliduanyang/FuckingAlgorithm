using System;

public class Solution {
    public bool OneEditAway(string first, string second) {
        int Min(int a, int b, int c) {
            return Math.Min(Math.Min(a, b), c);
        }

        var m = first.Length;
        var n = second.Length;
        if (m == 0 && n == 0) return true;
        var dp = new int[m + 1, n + 1];
        for (var i = 0; i <= m; ++i) dp[i, 0] = i;
        for (var i = 0; i <= n; ++i) dp[0, i] = i;
        for (var i = 1; i <= m; ++i) {
            for (var j = 1; j <= n; ++j) {
                if (first[i - 1] == second[j - 1]) {
                    dp[i, j] = dp[i - 1, j - 1];
                }
                else {
                    dp[i, j] = Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1, dp[i - 1, j - 1] + 1);
                }
            }
        }

        return dp[m, n] == 1;
    }
}