public class Solution {
    public bool IsInterleave(string s1, string s2, string s3) {
                int n = s1.Length, m = s2.Length, t = s3.Length;
                if (n + m != t) {
                    return false;
                }

                bool[,] dp = new bool [n + 1, m + 1];
                dp[0, 0] = true;
                for (int i = 0; i <= n; ++i) {
                    for (int j = 0; j <= m; ++j) {
                        int p = i + j - 1;
                        if (i > 0) {
                            dp[i, j] = dp[i, j] || (dp[i - 1, j] && s1[i - 1] == s3[p]);
                        }

                        if (j > 0) {
                            dp[i, j] = dp[i, j] || (dp[i, j - 1] && s2[j - 1] == s3[p]);
                        }
                    }
                }

                return dp[n, m];
    }
}