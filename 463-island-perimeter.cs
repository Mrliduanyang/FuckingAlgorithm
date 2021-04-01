public class Solution {
    public int IslandPerimeter(int[][] grid) {
        // 搜索上下左右的常用技巧
        int[] dx = {0, 1, 0, -1};
        int[] dy = {1, 0, -1, 0};

        int n = grid.Length, m = grid[0].Length;
        var ans = 0;
        for (var i = 0; i < n; ++i)
        for (var j = 0; j < m; ++j)
            if (grid[i][j] == 1) {
                var cnt = 0;
                // 统计每一个格子的边
                for (var k = 0; k < 4; ++k) {
                    var tx = i + dx[k];
                    var ty = j + dy[k];
                    if (tx < 0 || tx >= n || ty < 0 || ty >= m || grid[tx][ty] == 0) cnt += 1;
                }

                ans += cnt;
            }

        return ans;
    }
}