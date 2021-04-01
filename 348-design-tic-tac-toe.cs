public class TicTacToe {


                int n;
                int[,] rows;
                int[,] cols;
                int[,] diagonals;
                public TicTacToe(int n) {
                    this.n = n;
                    rows = new int[3, n];
                    cols = new int[3, n];
                    diagonals = new int[3, 2];

                }

                public int Move(int row, int col, int player) {
                    if (++rows[player, row] == n) return player;
                    if (++cols[player, col] == n) return player;
                    if (row == col && ++diagonals[player, 0] == n) return player;
                    if ((row + col == n - 1) && ++diagonals[player, 1] == n) return player;
                    return 0;

                }
}

/**
 * Your TicTacToe object will be instantiated and called as such:
 * TicTacToe obj = new TicTacToe(n);
 * int param_1 = obj.Move(row,col,player);
 */