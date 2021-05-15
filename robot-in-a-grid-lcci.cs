using System;
using System.Collections.Generic;

public class Solution {
    public IList<IList<int>> PathWithObstacles(int[][] obstacleGrid) {
        var res = new List<List<int>>();
        int m = obstacleGrid.Length, n = obstacleGrid[0].Length;
        if (obstacleGrid[0][0] == 1 || obstacleGrid[m - 1][n - 1] == 1) return res;
        var dp = new int[m, n];
        
        for (var i = 0; i < m; ++i) {
            if (obstacleGrid[i][0] == 1) break;
            dp[i, 0] = 1;
        }

        for (var i = 0; i < n; ++i) {
            if (obstacleGrid[0][i] == 1) break;
            dp[0, i] = 1;
        }
        
        for (var i = 1; i < m; i++) {
            for (var j = 1; j < n; j++) {
                if (obstacleGrid[i][j] == 1) {
                    dp[i, j] = 0;
                }
                else {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
        }

        if (dp[m - 1, n - 1] == 0) return res;
        int r = m - 1, c = n - 1;
        while (r != 0 || c != 0) {
            res.Add(new List<int> {r, c});
            int up = 0;
            if (r > 0) up = dp[r - 1, c];

            int left = 0;
            if (c > 0) left = dp[r, c - 1];

            if (up >= left) r--;
            else c--;
        }

        res.Add(new List<int> {0, 0});
        res.Reverse();
        return res;
    }
}