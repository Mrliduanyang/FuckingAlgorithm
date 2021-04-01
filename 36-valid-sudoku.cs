public class Solution {
    public bool IsValidSudoku(char[][] board) {
        var rows = new int[9, 9];
        var cols = new int[9, 9];
        var blocks = new int[9, 9];

        for (var i = 0; i < 9; i++)
        for (var j = 0; j < 9; j++)
            if (board[i][j] != '.') {
                var ele = int.Parse(board[i][j].ToString()) - 1;
                var k = i / 3 * 3 + j / 3;
                if (rows[i, ele] == 0 && cols[j, ele] == 0 && blocks[k, ele] == 0) {
                    rows[i, ele]++;
                    cols[j, ele]++;
                    blocks[k, ele]++;
                }
                else {
                    return false;
                }
            }

        return true;
    }
}