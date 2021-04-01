public class Solution {
    public int CountBattleships(char[][] board) {
        var res = 0;
        if (board.Length == 0) return 0;
        for (var i = 0; i < board.Length; i++)
        for (var j = 0; j < board[0].Length; j++)
            if (board[i][j] == 'X' && (i == 0 || board[i - 1][j] == '.') && (j == 0 || board[i][j - 1] == '.'))
                res++;
        return res;
    }
}