using System;

public class Solution {
    public int LongestCommonSubsequence(string text1, string text2) {
        int m = text1.Length, n = text2.Length;
        var dp = new int[m + 1, n + 1];
        for (int i = 1; i <= m; i++) {
            char c1 = text1[i - 1];
            for (int j = 1; j <= n; j++) {
                char c2 = text2[j - 1];
                if (c1 == c2) {
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                }
                else {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
        }

        return dp[m, n];
    }
}