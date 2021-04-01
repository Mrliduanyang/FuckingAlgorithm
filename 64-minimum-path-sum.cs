public class Solution {
    public int MinPathSum(int[][] grid) {
        if (grid == null || grid.Length == 0 || grid[0].Length == 0) return 0;
        var m = grid.Length;
        var n = grid[0].Length;
        var dp = new int[m, n];
        for (var i = 0; i < m; i++)
            if (i == 0)
                dp[i, 0] = grid[0][0];
            else
                dp[i, 0] = dp[i - 1, 0] + grid[i][0];
        for (var i = 0; i < n; i++)
            if (i == 0)
                dp[0, i] = grid[0][0];
            else
                dp[0, i] = dp[0, i - 1] + grid[0][i];
        for (var i = 1; i < m; i++)
        for (var j = 1; j < n; j++)
            dp[i, j] = Math.Min(dp[i - 1, j], dp[i, j - 1]) + grid[i][j];
        return dp[m - 1, n - 1];
    }
}