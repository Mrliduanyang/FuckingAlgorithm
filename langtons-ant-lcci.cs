using System;
using System.Collections.Generic;

public class Solution {
    public IList<string> PrintKMoves(int K) {
        var dirs = new[] {new[] {0, 1}, new[] {1, 0}, new[] {0, -1}, new[] {-1, 0}};
        var board = new char[3000][];
        for (var i = 0; i < 3000; ++i) {
            var tmp = new char[3000];
            Array.Fill(tmp, '_');
            board[i] = tmp;
        }

        var pos = new[] {'R', 'D', 'L', 'U'};
        int x = 2000, y = 2000, left = x, right = x, bottom = y, top = y;
        var dir = 0;
        for (var i = 0; i < K; ++i) {
            int d = 1;
            if (board[x][y] == 'X') d = 3;
            board[x][y] = board[x][y] == '_' ? 'X' : '_';
            dir = (dir + d) % 4;
            x += dirs[dir][0];
            y += dirs[dir][1];
            left = Math.Min(left, y);
            right = Math.Max(right, y);
            bottom = Math.Min(bottom, x);
            top = Math.Max(top, x);
        }

        board[x][y] = pos[dir];

        var res = new List<string>();
        for (var i = bottom; i <= top; ++i) {
            res.Add(string.Join("", board[i][left..(right + 1)]));
        }

        return res;
    }
}