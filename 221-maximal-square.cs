public class Solution {
    public int MaximalSquare(char[][] matrix) {
        var maxSide = 0;
        if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0) return maxSide;
        int rows = matrix.Length, columns = matrix[0].Length;
        var dp = new int[rows, columns];
        for (var i = 0; i < rows; i++)
        for (var j = 0; j < columns; j++)
            if (matrix[i][j] == '1') {
                if (i == 0 || j == 0)
                    dp[i, j] = 1;
                else
                    dp[i, j] = Math.Min(Math.Min(dp[i - 1, j], dp[i, j - 1]), dp[i - 1, j - 1]) + 1;
                maxSide = Math.Max(maxSide, dp[i, j]);
            }

        var maxSquare = maxSide * maxSide;
        return maxSquare;
    }
}