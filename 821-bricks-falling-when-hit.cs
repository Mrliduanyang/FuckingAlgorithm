public class Solution {
    private readonly int[] dirX = {-1, 0, 1, 0};
    private readonly int[] dirY = {0, 1, 0, -1};
    private List<int> num = new List<int>();

    private List<int> vector = new List<int>();

    private int Find(List<int> vector, int x) {
        if (vector[x] == x) return x;
        return Find(vector, vector[x]);
    }

    private void Union(List<int> vector, int x, int y) {
        var rx = Find(vector, x);
        var ry = Find(vector, y);
        if (rx == ry) return;

        if (rx == 0) {
            num[rx] += num[ry];
            vector[ry] = rx;
        }
        else if (ry == 0) {
            num[ry] += num[rx];
            vector[rx] = ry;
        }
        else {
            if (num[rx] >= num[ry]) {
                num[rx] += num[ry];
                vector[ry] = rx;
            }
            else {
                num[ry] += num[rx];
                vector[rx] = ry;
            }
        }
    }

    public int[] HitBricks(int[][] grid, int[][] hits) {
        var m = grid.Length;
        var n = grid[0].Length;
        // 0 是天花板
        vector.Add(0);
        num.Add(0);
        for (var i = 0; i < m * n; i++) {
            vector.Add(i + 1);
            num.Add(1);
        }

        // 第一行的跟天花板放在一个集合
        for (var i = 0; i < n; i++)
            if (grid[0][i] != 0)
                Union(vector, 0, i + 1);

        // 先把要敲掉的位置置0
        for (var i = 0; i < hits.Length; i++) {
            var r = hits[i][0];
            var c = hits[i][1];
            if (grid[r][c] == 0) {
                hits[i] = new[] {-1, -1};
                continue;
            }


            grid[r][c] = 0;
        }

        for (var r = 1; r < m; r++)
        for (var c = 0; c < n; c++) {
            if (grid[r][c] == 0) continue;
            for (var d = 0; d < 4; d++) {
                var i = r + dirX[d];
                var j = c + dirY[d];

                if (i < 0 || i >= m || j < 0 || j >= n || grid[i][j] == 0) continue;
                Union(vector, i * n + j + 1, r * n + c + 1);
            }
        }

        var res = new int[hits.Length];
        for (var i = hits.Length - 1; i >= 0; i--) {
            var r = hits[i][0];
            var c = hits[i][1];
            if (r == -1) {
                res[i] = 0;
                continue;
            }

            int preCount = num[0];
            grid[r][c] = 1;
            for (var d = 0; d < 4; d++) {
                var hi = r + dirX[d];
                var hj = c + dirY[d];

                if (hi < 0 || hi >= m || hj < 0 || hj >= n || grid[hi][hj] == 0) continue;
                Union(vector, hi * n + hj + 1, r * n + c + 1);
            }

            if (r == 0)
                res[i] = Math.Max(0, num[0] - preCount);
            else
                res[i] = Math.Max(0, num[0] - preCount - 1);
        }

        return res;
    }
}