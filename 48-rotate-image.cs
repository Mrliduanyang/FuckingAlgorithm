public class Solution {
    public void Rotate(int[][] matrix) {
        var n = matrix.Length;

        // transpose matrix
        for (var i = 0; i < n; i++)
        for (var j = i; j < n; j++) {
            var tmp = matrix[j][i];
            matrix[j][i] = matrix[i][j];
            matrix[i][j] = tmp;
        }

        // reverse each row
        for (var i = 0; i < n; i++)
        for (var j = 0; j < n / 2; j++) {
            var tmp = matrix[i][j];
            matrix[i][j] = matrix[i][n - j - 1];
            matrix[i][n - j - 1] = tmp;
        }
    }
}