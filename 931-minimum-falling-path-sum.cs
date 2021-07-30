using System;

public class Solution {
    public int MinFallingPathSum(int[][] matrix) {
        var n = matrix.Length;
        var dp = new int[n, n];
        for (var i = 0; i < n; ++i) {
            dp[0, i] = matrix[0][i];
        }

        for (var i = 1; i < n; ++i) {
            dp[i, 0] = Math.Min(dp[i - 1, 0], dp[i - 1, 1]) + matrix[i][0];
            for (var j = 1; j <= n - 2; ++j) {
                dp[i, j] = Math.Min(Math.Min(dp[i - 1, j], dp[i - 1, j - 1]), dp[i - 1, j + 1]) + matrix[i][j];
            }

            dp[i, n - 1] = Math.Min(dp[i - 1, n - 1], dp[i - 1, n - 2]) + matrix[i][n - 1];
        }

        var res = int.MaxValue;
        for (var i = 0; i < n; ++i) {
            res = Math.Min(res, dp[n - 1, i]);
        }

        return res;
    }
}