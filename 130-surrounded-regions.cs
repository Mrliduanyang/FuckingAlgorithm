public class Solution {
    public void Solve(char[][] board) {
        var rows = board.Length;
        if (rows == 0) return;
        var cols = board[0].Length;
        // 先把四周的点及跟他们相连的换成特殊字符。
        // 第一行
        for (var j = 0; j < cols; j++) Helper(board, 0, j, rows, cols);
        // 最后一行
        for (var j = 0; j < cols; j++) Helper(board, rows - 1, j, rows, cols);
        // 第一列
        for (var i = 0; i < rows; i++) Helper(board, i, 0, rows, cols);
        // 最后一列
        for (var i = 0; i < rows; i++) Helper(board, i, cols - 1, rows, cols);
        for (var i = 0; i < rows; i++)
        for (var j = 0; j < cols; j++) {
            if (board[i][j] == 'O') board[i][j] = 'X';
            if (board[i][j] == '#') board[i][j] = 'O';
        }
    }

    public void Helper(char[][] board, int x, int y, int rows, int cols) {
        if (x >= 0 && x <= rows - 1 && y >= 0 && y <= cols - 1 && board[x][y] == 'O') {
            board[x][y] = '#';
            // 深度遍历上下左右
            Helper(board, x - 1, y, rows, cols);
            Helper(board, x + 1, y, rows, cols);
            Helper(board, x, y - 1, rows, cols);
            Helper(board, x, y + 1, rows, cols);
        }
        else {
        }
    }
}