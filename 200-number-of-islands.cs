public class Solution {
    public int NumIslands(char[][] grid) {
        var m = grid.Length;
        if (m == 0) return 0;

        var n = grid[0].Length;

        void Helper(int r, int c) {
            grid[r][c] = '0';
            if (r - 1 >= 0 && grid[r - 1][c] == '1') Helper(r - 1, c);
            if (r + 1 < m && grid[r + 1][c] == '1') Helper(r + 1, c);
            if (c - 1 >= 0 && grid[r][c - 1] == '1') Helper(r, c - 1);
            if (c + 1 < n && grid[r][c + 1] == '1') Helper(r, c + 1);
        }

        var res = 0;
        for (var r = 0; r < m; ++r)
        for (var c = 0; c < n; ++c)
            if (grid[r][c] == '1') {
                res++;
                Helper(r, c);
            }

        return res;
    }
}