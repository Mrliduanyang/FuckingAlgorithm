public class Solution {
    public void SolveSudoku(char[][] board) {
        var rows = new bool[9, 10];
        var cols = new bool[9, 10];
        var boxes = new bool[3, 3, 10];
        for (var i = 0; i < board.Length; i++)
        for (var j = 0; j < board[0].Length; j++) {
            var num = board[i][j] - '0';
            if (1 <= num && num <= 9) {
                rows[i, num] = true;
                cols[j, num] = true;
                boxes[i / 3, j / 3, num] = true;
            }
        }

        bool Helper(int row, int col) {
            // 边界校验, 如果已经填充完成, 返回true, 表示一切结束
            if (col == board[0].Length) {
                col = 0;
                row++;
                if (row == board.Length) return true;
            }

            // 是空则尝试填充, 否则跳过继续尝试填充下一个位置
            if (board[row][col] == '.') // 尝试填充1~9
                for (var num = 1; num <= 9; num++) {
                    var canUsed = !(rows[row, num] || cols[col, num] || boxes[row / 3, col / 3, num]);
                    if (canUsed) {
                        rows[row, num] = true;
                        cols[col, num] = true;
                        boxes[row / 3, col / 3, num] = true;
                        board[row][col] = (char) ('0' + num);
                        if (Helper(row, col + 1)) return true;
                        board[row][col] = '.';
                        rows[row, num] = false;
                        cols[col, num] = false;
                        boxes[row / 3, col / 3, num] = false;
                    }
                }
            else
                return Helper(row, col + 1);

            return false;
        }

        Helper(0, 0);
    }
}