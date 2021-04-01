public class Solution {
    public int MaxAreaOfIsland(int[][] grid) {
        var directions = new[] {new[] {0, 1}, new[] {0, -1}, new[] {-1, 0}, new[] {1, 0}};
        var res = 0;

        int Helper(int row, int col) {
            if (row < 0 || col < 0 || row == grid.Length || col == grid[0].Length || grid[row][col] == 0) return 0;
            grid[row][col] = 0;
            var area = 1;
            foreach (var direction in directions) {
                int tx = row + direction[0], ty = col + direction[1];
                area += Helper(tx, ty);
            }

            res = Math.Max(res, area);
            return area;
        }

        for (var i = 0; i != grid.Length; ++i)
        for (var j = 0; j != grid[0].Length; ++j)
            Helper(i, j);
        return res;
    }
}