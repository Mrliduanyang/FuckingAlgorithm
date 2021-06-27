using System;
using System.Collections.Generic;

public class Solution {
    public int SnakesAndLadders(int[][] board) {
        var n = board.Length;
        var vis = new bool[n * n + 1];

        Tuple<int, int> Id2Rc(int id) {
            int r = (id - 1) / n, c = (id - 1) % n;
            if (r % 2 == 1) {
                c = n - 1 - c;
            }

            return new Tuple<int, int>(n - 1 - r, c);
        }

        var queue = new Queue<Tuple<int, int>>();
        queue.Enqueue(new Tuple<int, int>(1, 0));
        while (queue.Count != 0) {
            var cur = queue.Dequeue();
            for (var i = 1; i <= 6; ++i) {
                var next = cur.Item1 + i;
                if (next > n * n) break;
                var rc = Id2Rc(next);
                if (board[rc.Item1][rc.Item2] > 0) {
                    next = board[rc.Item1][rc.Item2];
                }

                if (next == n * n) return cur.Item2 + 1;
                if (!vis[next]) {
                    vis[next] = true;
                    queue.Enqueue(new Tuple<int, int>(next, cur.Item2 + 1));
                }
            }
        }

        return -1;
    }
}