using System.Collections.Generic;

public class Solution {
    public int KthLargestValue(int[][] matrix, int k) {
        int m = matrix.Length, n = matrix[0].Length;
        var pre = new int[m + 1, n + 1];
        var results = new List<int>();
        for (var i = 1; i <= m; ++i) {
            for (var j = 1; j <= n; ++j) {
                pre[i, j] = pre[i - 1, j] ^ pre[i, j - 1] ^ pre[i - 1, j - 1] ^ matrix[i - 1][j - 1];
                results.Add(pre[i, j]);
            }
        }

        results.Sort((num1, num2) => num2 - num1);
        return results[k - 1];
    }
}