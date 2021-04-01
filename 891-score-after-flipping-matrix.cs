public class Solution {
    public int MatrixScore(int[][] A) {
                int m = A.Length, n = A[0].Length;
                // 翻转第一列为0的行
                for (int i = 0; i < m; i++) {
                    if (A[i][0] == 0) {
                        for (int j = 0; j < n; j++) {
                            A[i][j] = (1 - A[i][j]);
                        }
                    }
                }
                for (int j = 0; j < n; j++) {
                    int zeroCount = 0, oneCount = 0;
                    for (int i = 0; i < m; i++) {
                        if (A[i][j] == 0) {
                            zeroCount++;
                        } else {
                            oneCount++;
                        }
                    }
                    if (zeroCount > oneCount) {
                        for (int i = 0; i < m; i++) {
                            A[i][j] = (1 - A[i][j]);
                        }
                    }
                }
                int res = 0;
                foreach (var row in A) {
                    int rowScore = 0;
                    foreach (var x in row) {
                        rowScore = (rowScore * 2 + x);
                    }
                    res += rowScore;
                }
                return res;
    }
}