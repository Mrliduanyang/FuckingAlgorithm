public class Solution {
    public int[][] Transpose(int[][] matrix) {
        int m = matrix.Length, n = matrix[0].Length;
        var transposed = new int[n][];
        for (var i = 0; i < n; i++) transposed[i] = new int[m];
        for (var i = 0; i < m; i++)
        for (var j = 0; j < n; j++)
            transposed[j][i] = matrix[i][j];
        return transposed;
    }
}