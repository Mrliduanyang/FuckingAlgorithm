using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public IList<IList<string>> SolveNQueens(int n) {
        var res = new List<IList<string>>();

        bool IsValid(char[][] board, int row, int col) {
            // 判断列上是否有皇后
            for (var i = 0; i < n; i++)
                if (board[i][col] == 'Q')
                    return false;
            // 检查右上方是否有皇后互相冲突
            for (int i = row - 1, j = col + 1; i >= 0 && j < n; i--, j++)
                if (board[i][j] == 'Q')
                    return false;
            // 检查左上方是否有皇后互相冲突
            for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
                if (board[i][j] == 'Q')
                    return false;
            return true;
        }

        void Helper(char[][] board, int row) {
            if (row == n) {
                var tmp = board.Select(item => string.Join("", item)).ToList();
                res.Add(tmp);
                return;
            }

            for (var col = 0; col < n; col++) {
                if (!IsValid(board, row, col)) continue;
                board[row][col] = 'Q';
                Helper(board, row + 1);
                board[row][col] = '.';
            }
        }

        var board = new char[n][];
        for (var i = 0; i < n; i++) {
            var tmp = new char[n];
            Array.Fill(tmp, '.');
            board[i] = tmp;
        }

        Helper(board, 0);

        return res;
    }
}