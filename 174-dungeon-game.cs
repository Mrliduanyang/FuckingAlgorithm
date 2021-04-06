using System;

public class Solution {
    public int CalculateMinimumHP(int[][] dungeon) {
        int m = dungeon.Length, n = dungeon[0].Length;
        var dp = new int[m, n];
        dp[m - 1, n - 1] = Math.Max(1 - dungeon[m - 1][n - 1], 1);
        for (var i = m - 2; i >= 0; --i) {
            dp[i, n - 1] = Math.Max(dp[i + 1, n - 1] - dungeon[i][n - 1], 1);
        }

        for (var i = n - 2; i >= 0; --i) {
            dp[m - 1, i] = Math.Max(dp[m - 1, i + 1] - dungeon[m - 1][i], 1);
        }

        for (var i = m - 2; i >= 0; --i) {
            for (var j = n - 2; j >= 0; --j) {
                var mindp = Math.Min(dp[i + 1, j], dp[i, j + 1]) - dungeon[i][j];
                dp[i, j] = Math.Max(mindp, 1);
            }
        }

        return dp[0, 0];
    }
}