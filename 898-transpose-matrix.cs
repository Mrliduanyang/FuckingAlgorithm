public class Solution {
    public int[][] Transpose(int[][] matrix) {
                int m = matrix.Length, n = matrix[0].Length;
                int[][] transposed = new int[n][];
                for (int i = 0; i < n; i++) {
                    transposed[i] = new int[m];
                }
                for (int i = 0; i < m; i++) {
                    for (int j = 0; j < n; j++) {
                        transposed[j][i] = matrix[i][j];
                    }
                }
                return transposed;
    }
}