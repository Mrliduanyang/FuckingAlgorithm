public class Solution {
    public int MinCut(string s) {
                int n = s.Length;
                var dp = new bool[n][];
                for (int i = 0; i < n; ++i) {
                    dp[i] = new bool[n];
                    Array.Fill(dp[i], true);
                }

                for (int i = n - 1; i >= 0; --i) {
                    for (int j = i + 1; j < n; ++j) {
                        dp[i][j] = s[i] == s[j] && dp[i + 1][j - 1];
                    }
                }

                int[] f = new int[n];
                Array.Fill(f, int.MaxValue);
                for (int i = 0; i < n; ++i) {
                    if (dp[0][i]) {
                        f[i] = 0;
                    } else {
                        for (int j = 0; j < i; ++j) {
                            if (dp[j + 1][i]) {
                                f[i] = Math.Min(f[i], f[j] + 1);
                            }
                        }
                    }
                }
                return f[n - 1];
    }
}