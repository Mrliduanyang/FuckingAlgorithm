using System;
using System.Collections.Generic;

public class Solution {
    public int ShortestPath(int[][] grid, int k) {
        var n = grid.Length;
        var m = grid[0].Length;
        if (n == 1 && m == 1) return 0;
        var vis = new bool[n, m, k + 1];
        var queue = new Queue<Tuple<int, int, int>>();
        queue.Enqueue(new Tuple<int, int, int>(0, 0, k));
        vis[0, 0, 1] = true;

        var dirs = new[] {new[] {-1, 0}, new[] {1, 0}, new[] {0, -1}, new[] {0, 1}};

        var step = 1;
        while (queue.Count != 0) {
            var count = queue.Count;
            for (var i = 0; i < count; ++i) {
                var curPos = queue.Dequeue();
                foreach (var dir in dirs) {
                    var x = dir[0] + curPos.Item1;
                    var y = dir[1] + curPos.Item2;

                    if (x >= 0 && x < n && y >= 0 && y < m) {
                        if (grid[x][y] == 0 && !vis[x, y, curPos.Item3]) {
                            if (x == n - 1 && y == m - 1) {
                                return step;
                            }

                            queue.Enqueue(new Tuple<int, int, int>(x, y, curPos.Item3));
                            vis[x, y, curPos.Item3] = true;
                        }
                        else if (grid[x][y] == 1 && curPos.Item3 > 0 && !vis[x, y, curPos.Item3 - 1]) {
                            queue.Enqueue(new Tuple<int, int, int>(x, y, curPos.Item3 - 1));
                            vis[x, y, curPos.Item3 - 1] = true;
                        }
                    }
                }
            }

            ++step;
        }

        return -1;
    }
}