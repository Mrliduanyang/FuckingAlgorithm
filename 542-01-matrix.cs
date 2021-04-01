public class Solution {
    public int[][] UpdateMatrix(int[][] matrix) {
                int m = matrix.Length, n = matrix[0].Length;
                var dirs = new [] { new [] {-1, 0 }, new [] { 1, 0 }, new [] { 0, -1 }, new [] { 0, 1 } };
                var res = new int[m][];
                for (int i = 0; i < m; i++) {
                    res[i] = new int[n];
                }
                bool[, ] vis = new bool[m, n];
                var queue = new Queue<Tuple<int, int>>();
                for (int i = 0; i < m; ++i) {
                    for (int j = 0; j < n; ++j) {
                        if (matrix[i][j] == 0) {
                            queue.Enqueue(new Tuple<int, int>(i, j));
                            vis[i, j] = true;
                        }
                    }
                }
                while (queue.Count != 0) {
                    (var i, var j) = queue.Dequeue();
                    for (int d = 0; d < 4; ++d) {
                        int ni = i + dirs[d][0];
                        int nj = j + dirs[d][1];
                        if (ni >= 0 && ni < m && nj >= 0 && nj < n && !vis[ni, nj]) {
                            res[ni][nj] = res[i][j] + 1;
                            queue.Enqueue(new Tuple<int, int>(ni, nj));
                            vis[ni,nj] = true;
                        }
                    }
                }

                return res;
    }
}