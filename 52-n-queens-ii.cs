public class Solution {
    private List<char[,]> res = new List<char[,]>();

    public int TotalNQueens(int n) {
        var board = new char[n, n];
        for (var i = 0; i < n; i++)
        for (var j = 0; j < n; j++)
            board[i, j] = '.';
        Backtrack(board, 0);
        return res.Count;
    }

    public bool IsValid(char[,] board, int row, int col) {
        var n = board.GetLength(0);
        // 判断列上是否有皇后
        for (var i = 0; i < n; i++)
            if (board[i, col] == 'Q')
                return false;
        // 检查右上方是否有皇后互相冲突
        for (int i = row - 1, j = col + 1; i >= 0 && j < n; i--, j++)
            if (board[i, j] == 'Q')
                return false;
        // 检查左上方是否有皇后互相冲突
        for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
            if (board[i, j] == 'Q')
                return false;
        return true;
    }

    public void Backtrack(char[,] board, int row) {
        if (row == board.GetLength(0)) {
            res.Add(board);
            return;
        }

        var cols = board.GetLength(1);
        for (var col = 0; col < cols; col++) {
            if (!IsValid(board, row, col)) continue;
            board[row, col] = 'Q';
            Backtrack(board, row + 1);
            board[row, col] = '.';
        }
    }
}