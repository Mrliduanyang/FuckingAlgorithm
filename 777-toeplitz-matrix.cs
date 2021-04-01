public class Solution {
    public bool IsToeplitzMatrix(int[][] matrix) {
        int m = matrix.Length, n = matrix[0].Length;
        for (var i = 1; i < m; i++)
        for (var j = 1; j < n; j++)
            if (matrix[i][j] != matrix[i - 1][j - 1])
                return false;
        return true;
    }
}