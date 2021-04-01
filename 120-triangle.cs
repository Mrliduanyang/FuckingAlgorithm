public class Solution {
    public int MinimumTotal(IList<IList<int>> triangle) {
if (triangle.Count == 0) {
                    return 0;
                }
                int n = triangle.Count;
                var dp = new int[n, n];
                // base
                dp[0, 0] = triangle[0][0];
                for (int i = 1; i < n; i++) {
                    dp[i, 0] = dp[i - 1, 0] + triangle[i][0];
                    dp[i, i] = dp[i - 1, i - 1] + triangle[i][i];
                }
                for (int i = 1; i < n; i++) {
                    for (int j = 0; j < i; j++) {
                        if (i == j) {
                            dp[i, j] = dp[i - 1, j - 1] + triangle[i][j];
                        } else if (j == 0) {
                            dp[i, 0] = dp[i - 1, 0] + triangle[i][0];
                        } else {
                            dp[i, j] = Math.Min(dp[i - 1, j - 1], dp[i - 1, j]) + triangle[i][j];
                        }
                    }
                }
                int res = int.MaxValue;
                for (int i = 0; i < n; i++) {
                    res = Math.Min(dp[n - 1, i], res);
                }
                return res;
    }
}