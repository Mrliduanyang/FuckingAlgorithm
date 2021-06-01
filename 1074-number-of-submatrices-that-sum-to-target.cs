public class Solution {
    public int NumSubmatrixSumTarget(int[][] matrix, int target) {
        int m = matrix.Length, n = matrix[0].Length;
        var preSum = new int[m + 1, n + 1];
        for (var i = 1; i <= m; ++i) {
            for (var j = 1; j <= n; j++) {
                preSum[i, j] = preSum[i - 1, j] + preSum[i, j - 1] - preSum[i - 1, j - 1] + matrix[i - 1][j - 1];
            }
        }

        var res = 0;
        for (var i = 1; i <= m; ++i) {
            for (var j = 1; j <= n; ++j) {
                for (var p = 1; p <= i; ++p) {
                    for (var q = 1; q <= j; ++q) {
                        if (preSum[i, j] - preSum[p - 1, j] - preSum[i, q - 1] + preSum[p - 1, q - 1] == target) ++res;
                    }
                }
            }
        }

        return res;
    }
}