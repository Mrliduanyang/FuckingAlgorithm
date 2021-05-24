using System;

public class Solution {
    public int StrangePrinter(string s) {
        var n = s.Length;
        var dp = new int[n, n];
        for (var i = n - 1; i >= 0; i--) {
            dp[i, i] = 1;
            for (var j = i + 1; j < n; j++) {
                if (s[i] == s[j]) {
                    dp[i, j] = dp[i, j - 1];
                }
                else {
                    var minn = int.MaxValue;
                    for (var k = i; k < j; k++) {
                        minn = Math.Min(minn, dp[i, k] + dp[k + 1, j]);
                    }

                    dp[i, j] = minn;
                }
            }
        }

        return dp[0, n - 1];
    }
}