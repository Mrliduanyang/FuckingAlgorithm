using System.Collections.Generic;

public class Solution {
    public int[] PondSizes(int[][] land) {
        var res = new List<int>();
        int m = land.Length, n = land[0].Length;

        int Helper(int i, int j) {
            if (i < 0 || i >= m || j < 0 || j >= n || land[i][j] != 0) {
                return 0;
            }

            land[i][j] = int.MaxValue;
            return 1 + Helper(i - 1, j) +
                   Helper(i - 1, j - 1) +
                   Helper(i - 1, j + 1) +
                   Helper(i + 1, j) +
                   Helper(i + 1, j - 1) +
                   Helper(i + 1, j + 1) +
                   Helper(i, j - 1) +
                   Helper(i, j + 1);
        }

        for (var i = 0; i < m; ++i) {
            for (var j = 0; j < n; ++j) {
                if (land[i][j] == 0) {
                    var area = Helper(i, j);
                    res.Add(area);
                }
            }
        }

        res.Sort();
        return res.ToArray();
    }
}