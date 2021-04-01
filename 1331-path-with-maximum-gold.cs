public class Solution {
    public int GetMaximumGold(int[][] grid) {
        var dirs = new[] {new[] {0, 1}, new[] {0, -1}, new[] {1, 0}, new[] {-1, 0}};
        var res = 0;
        int m = grid.Length, n = grid[0].Length;
        var vis = new bool[m, n];

        void Helper(int i, int j, int sum) {
            if (vis[i, j] || grid[i][j] == 0) {
                if (sum > res) res = sum;
                return;
            }

            sum += grid[i][j];
            vis[i, j] = true;
            foreach (var dir in dirs) {
                var tx = i + dir[0];
                var ty = j + dir[1];
                if (tx < 0 || ty < 0 || tx >= m || ty >= n) continue;
                Helper(tx, ty, sum);
            }

            sum -= grid[i][j];
            vis[i, j] = false;
        }

        for (var i = 0; i < m; i++)
        for (var j = 0; j < n; j++)
            if (grid[i][j] != 0)
                Helper(i, j, 0);
        return res;
    }
}