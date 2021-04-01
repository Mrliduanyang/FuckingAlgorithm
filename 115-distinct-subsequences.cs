public class Solution {
    public int NumDistinct(string s, string t) {
                int m = s.Length, n = t.Length;
                if (m < n) {
                    return 0;
                }
                var dp = new int[m + 1, n + 1];
                for (int i = 0; i <= m; i++) {
                    dp[i, n] = 1;
                }
                for (int i = m - 1; i >= 0; i--) {
                    for (int j = n - 1; j >= 0; j--) {
                        if (s[i] == t[j]) {
                            dp[i, j] = dp[i + 1, j + 1] + dp[i + 1, j];
                        } else {
                            dp[i, j] = dp[i + 1, j];
                        }
                    }
                }
                return dp[0, 0];
    }
}