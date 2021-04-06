using System;

public class Solution {
    public int MinimumMoves(int[] arr) {
        var n = arr.Length;
        var dp = new int [n, n];
        for (var i = 0; i < n; ++i) dp[i, i] = 1;
        for (var i = 0; i < n - 1; ++i) {
            dp[i, i + 1] = arr[i] == arr[i + 1] ? 1 : 2;
        }

        for (var j = 2; j < n; ++j) {
            for (var i = j - 2; i >= 0; --i) {
                var min = n;
                if (arr[i] == arr[j])
                    min = dp[i + 1, j - 1];

                for (var k = i; k < j; k++)
                    min = Math.Min(min, dp[i, k] + dp[k + 1, j]);

                dp[i, j] = min;
            }
        }

        return dp[0, n - 1];
    }
}