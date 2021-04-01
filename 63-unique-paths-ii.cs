public class Solution {
    public int UniquePathsWithObstacles(int[][] obstacleGrid) {
        if (obstacleGrid == null || obstacleGrid.Length <= 0 || obstacleGrid[0].Length <= 0) return 0;

        var m = obstacleGrid.Length;
        var n = obstacleGrid[0].Length;
        var dp = new int[m, n];
        for (var i = 0; i < obstacleGrid[0].Length; ++i) {
            if (obstacleGrid[0][i] == 1) break;
            dp[0, i] = 1;
        }

        for (var i = 0; i < obstacleGrid.Length; ++i) {
            if (obstacleGrid[i][0] == 1) break;
            dp[i, 0] = 1;
        }

        for (var i = 1; i < m; i++)
        for (var j = 1; j < n; j++)
            if (obstacleGrid[i][j] == 1) {
                dp[i, j] = 0;
            }
            else {
                dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
            }

        return dp[m - 1, n - 1];
    }
}