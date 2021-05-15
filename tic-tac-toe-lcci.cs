public class Solution {
    public string Tictactoe(string[] board) {
        bool Helper(char player) {
            for (int i = 0; i < 3; ++i) {
                if (player == board[0][i] && player == board[1][i] && player == board[2][i])
                    return true;
                if (player == board[i][0] && player == board[i][1] && player == board[i][2])
                    return true;
            }

            if (player == board[0][0] && player == board[1][1] && player == board[2][2])
                return true;
            if (player == board[0][2] && player == board[1][1] && player == board[2][0])
                return true;
            return false;
        }

        int xCount = 0, oCount = 0;
        foreach (var row in board) {
            foreach (var ch in row) {
                if (ch == 'X') ++xCount;
                if (ch == 'O') ++oCount;
            }
        }

        if (oCount != xCount && oCount != xCount - 1) return false;
        if (Helper('X') && oCount != xCount - 1) return false;
        if (Helper('O') && oCount != xCount) return false;
        return true;
    }
}