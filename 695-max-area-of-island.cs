public class Solution {
    public int MaxAreaOfIsland(int[][] grid) {
                var directions = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { -1, 0 }, new int[] { 1, 0 } };
                int res = 0;

                int Helper(int row, int col) {
                    if (row < 0 || col < 0 || row == grid.Length || col == grid[0].Length || grid[row][col] == 0) {
                        return 0;
                    }
                    grid[row][col] = 0;
                    int area = 1;
                    foreach (var direction in directions) {
                        int tx = row + direction[0], ty = col + direction[1];
                        area += Helper(tx, ty);
                    }
                    res = Math.Max(res, area);
                    return area;
                }
                for (int i = 0; i != grid.Length; ++i) {
                    for (int j = 0; j != grid[0].Length; ++j) {
                        Helper(i, j);
                    }
                }
                return res;
    }
}