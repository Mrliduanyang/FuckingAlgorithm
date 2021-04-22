using System;

public class Solution {
    public int MaxSumSubmatrix(int[][] matrix, int k) {
        var n = matrix.Length;
        var m = matrix[0].Length;
        var sum = new int[n + 1, m + 1];
        for (var i = 1; i <= n; i++) {
            for (var j = 1; j <= m; j++) {
                sum[i, j] = sum[i - 1, j] + sum[i, j - 1] - sum[i - 1, j - 1] + matrix[i - 1][j - 1];
            }
        }

        var ans = int.MinValue;
        for (var i = 1; i <= n; i++) {
            for (var j = 1; j <= m; j++) {
                for (var p = i; p <= n; p++) {
                    for (var q = j; q <= m; q++) {
                        var cur = sum[p, q] - sum[i - 1, q] - sum[p, j - 1] + sum[i - 1, j - 1];
                        if (cur <= k) {
                            ans = Math.Max(ans, cur);
                        }
                    }
                }
            }
        }

        return ans;
    }
}