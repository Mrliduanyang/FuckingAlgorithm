public class Solution {
    public int OrangesRotting(int[][] grid) {
                int m = grid.Length, n = grid[0].Length;
                var directions = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
                var queue = new Queue<Tuple<int, int>>();
                int num = 0, res = 0;
                for (int i = 0; i < m; ++i) {
                    for (int j = 0; j < n; ++j) {
                        if (grid[i][j] == 1) {
                            ++num;
                        } else if (grid[i][j] == 2) {
                            queue.Enqueue(new Tuple<int, int>(i, j));
                        }
                    }
                }
                while (num > 0 && queue.Count != 0) {
                    ++res;
                    int count = queue.Count;
                    for (int i = 0; i < count; ++i) {
                        var (row, col) = queue.Dequeue();
                        foreach (var direction in directions) {
                            int tx = row + direction[0], ty = col + direction[1];
                            if (tx >= 0 && tx < m && ty >= 0 && ty < n && grid[tx][ty] == 1) {
                                grid[tx][ty] = 2;
                                num--;
                                queue.Enqueue(new Tuple<int, int>(tx, ty));
                            }
                        }
                    }
                }
                return num > 0 ? -1 : res;
    }
}